#include <windows.h>  

#define IDE_ATAPI_IDENTIFY 0xA1 // Returns ID sector for ATAPI.    
#define IDE_ATA_IDENTIFY    0xEC // Returns ID sector for ATA.    

BOOL __fastcall DoIdentify(HANDLE hPhysicalDriveIOCTL,
    PSENDCMDINPARAMS pSCIP,
    PSENDCMDOUTPARAMS pSCOP,
    BYTE btIDCmd,
    BYTE btDriveNum,
    PDWORD pdwBytesReturned)
{
    pSCIP->cBufferSize = IDENTIFY_BUFFER_SIZE;
    pSCIP->irDriveRegs.bFeaturesReg = 0;
    pSCIP->irDriveRegs.bSectorCountReg = 1;
    pSCIP->irDriveRegs.bSectorNumberReg = 1;
    pSCIP->irDriveRegs.bCylLowReg = 0;
    pSCIP->irDriveRegs.bCylHighReg = 0;

    pSCIP->irDriveRegs.bDriveHeadReg = (btDriveNum & 1) ? 0xB0 : 0xA0;
    pSCIP->irDriveRegs.bCommandReg = btIDCmd;
    pSCIP->bDriveNumber = btDriveNum;
    pSCIP->cBufferSize = IDENTIFY_BUFFER_SIZE;

    return DeviceIoControl(hPhysicalDriveIOCTL,
        SMART_RCV_DRIVE_DATA,
        (LPVOID)pSCIP,
        sizeof(SENDCMDINPARAMS) - 1,
        (LPVOID)pSCOP,
        sizeof(SENDCMDOUTPARAMS) + IDENTIFY_BUFFER_SIZE - 1,
        pdwBytesReturned, NULL);
}

char* __fastcall ConvertToString(DWORD dwDiskData[256], int nFirstIndex, int nLastIndex)
{
    static char szResBuf[1024];
    char ss[256];
    int nIndex = 0;
    int nPosition = 0;

    for (nIndex = nFirstIndex; nIndex <= nLastIndex; nIndex++)
    {
        ss[nPosition] = (char)(dwDiskData[nIndex] / 256);
        nPosition++;

        // Get low BYTE for 2nd character  
        ss[nPosition] = (char)(dwDiskData[nIndex] % 256);
        nPosition++;
    }

    // End the string  
    ss[nPosition] = '\0';

    int i, index = 0;
    for (i = 0; i < nPosition; i++)
    {
        if (ss[i] == 0 || ss[i] == 32)    continue;
        szResBuf[index] = ss[i];
        index++;
    }
    szResBuf[index] = 0;

    return szResBuf;
}

int main()
{
    HANDLE hFile = ::CreateFile(@"\\.\PhysicalDrive0",
        GENERIC_READ | GENERIC_WRITE,
        FILE_SHARE_READ | FILE_SHARE_WRITE,
        NULL, OPEN_EXISTING,
        0, NULL);
    DWORD dwBytesReturned;
    GETVERSIONINPARAMS gvopVersionParams;
    DeviceIoControl(hFile,       //���豸������SMART_GET_VERSION�豸���󣬻�ȡӲ������  
        SMART_GET_VERSION,
        NULL,
        0,
        &gvopVersionParams,
        sizeof(gvopVersionParams),
        &dwBytesReturned, NULL);
    if (gvopVersionParams.bIDEDeviceMap <= 0)    return -2;
    //2���ڶ���������SMART_RCV_DRIVE_DATA�豸���󣬻�ȡӲ����ϸ��Ϣ��  
        // IDE or ATAPI IDENTIFY cmd  
    int btIDCmd = 0;
    SENDCMDINPARAMS InParams;
    int nDrive = 0;
    btIDCmd = (gvopVersionParams.bIDEDeviceMap >> nDrive & 0x10) ? IDE_ATAPI_IDENTIFY : IDE_ATA_IDENTIFY;


    // �������  
    BYTE btIDOutCmd[sizeof(SENDCMDOUTPARAMS) + IDENTIFY_BUFFER_SIZE - 1];

    if (DoIdentify(hFile,
        &InParams,
        (PSENDCMDOUTPARAMS)btIDOutCmd,
        (BYTE)btIDCmd,
        (BYTE)nDrive, &dwBytesReturned) == FALSE)    return -3;
    ::CloseHandle(hFile);

    DWORD dwDiskData[256];
    USHORT* pIDSector; // ��Ӧ�ṹIDSECTOR����ͷ�ļ�  

    pIDSector = (USHORT*)((SENDCMDOUTPARAMS*)btIDOutCmd)->bBuffer;
    for (int i = 0; i < 256; i++)    dwDiskData[i] = pIDSector[i];

    char szSerialNumber[MAX_PATH], szModelNumber[MAX_PATH];
    // ȡϵ�к�  
    ZeroMemory(szSerialNumber, sizeof(szSerialNumber));
    strcpy(szSerialNumber, ConvertToString(dwDiskData, 10, 19));

    // ȡģ�ͺ�  
    ZeroMemory(szModelNumber, sizeof(szModelNumber));
    strcpy(szModelNumber, ConvertToString(dwDiskData, 27, 46));

    MessageBoxA(0, szSerialNumber, 0, 0);
    MessageBoxA(0, szModelNumber, 0, 0);

    return 0;
}