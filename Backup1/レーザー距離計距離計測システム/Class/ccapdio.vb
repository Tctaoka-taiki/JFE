Option Strict Off
Option Explicit On 
Module DIO
	'======================================================================
	'======================================================================
	'	API-CAP(W32)
	'	CCAPDIO.VB					CONTEC.CO.,LTD.
	'======================================================================
	'======================================================================


	'======================================================================
	' Error Code
	'======================================================================
    Public Const DIO_ERR_SUCCESS As Integer = 0                     '正常終了 
    Public Const DIO_ERR_INI_MEMORY As Integer = 3                  'メモリの割り当てに失敗しました。 
    Public Const DIO_ERR_INI_REGISTRY As Integer = 4                '設定ファイルのアクセスに失敗しました。 
    Public Const DIO_ERR_DLL_DEVICE_NAME As Integer = 10000         '設定ファイルに登録されていないデバイス名が指定されました。 
    Public Const DIO_ERR_DLL_INVALID_ID As Integer = 10001          '無効なIDが指定されました。 
    Public Const DIO_ERR_DLL_CREATE_FILE As Integer = 10003         'ハンドルの取得に作成に失敗しました。 
    Public Const DIO_ERR_DLL_CLOSE_FILE As Integer = 10004          'ハンドルのクローズに失敗しました。 
    Public Const DIO_ERR_ACCESS_RIGHT As Integer = 10005            'アクセス権エラーです。
    Public Const DIO_ERR_DLL_TIMEOUT As Integer = 10006             '通信タイムアウトが発生しました。
    Public Const DIO_ERR_COMPOSITION As Integer = 10007             '機器構成エラーです。
    Public Const DIO_ERR_INFO_INVALID_DEVICE As Integer = 10050     '指定したデバイス名称が見つかりません。スペルを確認してください。 
    Public Const DIO_ERR_INFO_NOT_FIND_DEVICE As Integer = 10051    '利用可能なデバイスが見つかりません。 
    Public Const DIO_ERR_DLL_BUFF_ADDRESS As Integer = 10100        'データバッファアドレスが不正です。 
    Public Const DIO_ERR_SYS_NOT_SUPPORTED As Integer = 20001       'このデバイスではこの関数は使用できません。
    Public Const DIO_ERR_SYS_PORT_NO As Integer = 20100             'ポート番号が指定可能範囲を超えています。 
    Public Const DIO_ERR_SYS_PORT_NUM As Integer = 20101            'ポート数が指定可能範囲を超えています。 
    Public Const DIO_ERR_SYS_BIT_NO As Integer = 20102              'ビット番号が指定可能範囲を超えています。 
    Public Const DIO_ERR_SYS_BIT_NUM As Integer = 20103             'ビット数が指定可能範囲を超えています。 
    Public Const DIO_ERR_SYS_BIT_DATA As Integer = 20104            'ビットデータが0か1以外です。 
    Public Const DIO_ERR_SYS_DIRECTION As Integer = 20106           '入出力方向が指定範囲外です。
    Public Const DIO_ERR_SYS_FILTER As Integer = 20400              'フィルタ時定数が指定範囲外です。 

	'======================================================================
	' Function Prototype
	'======================================================================
	Declare Function DioInit Lib "CCAPDIO.DLL" (ByVal Devicename As String, ByRef Id As Short) As Integer
	Declare Function DioExit Lib "CCAPDIO.DLL" (ByVal Id As Short) As Integer
    Declare Function DioGetErrorString Lib "CCAPDIO.DLL" (ByVal Err As Integer, ByVal szMsg As System.Text.StringBuilder) As Integer
    Declare Function DioQueryDeviceName Lib "CCAPDIO.DLL" (ByVal Index As Short, ByRef GroupID As Short, ByRef UnitID As Short, ByRef DeviceID As Short, ByVal DeviceName As System.Text.StringBuilder, ByVal Device As System.Text.StringBuilder) As Integer
	Declare Function DioSetAccessRight Lib "CCAPDIO.DLL" (ByRef AccsRight As Byte) As Integer
	Declare Function DioSetDirectMode Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal DirectMode As Short) As Integer
	Declare Function DioSetIOInterval Lib "CCAPDIO.DLL" (ByVal Interval As Integer) As Integer
	Declare Function DioGetRemoteStatus Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef Start As Byte, ByRef Status As Byte) As Integer
	Declare Function DioSetDigitalFilter Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal FilterValue As Short) As Integer
	Declare Function DioGetDigitalFilter Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef FilterValue As Short) As Integer
	Declare Function DioSetIoDirection Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal Dir As Integer) As Integer
	Declare Function DioGetIoDirection Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef Dir As Integer) As Integer
	Declare Function DioInpByte Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal PortNo As Short, ByRef Data As Byte) As Integer
	Declare Function DioInpBit Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal BitNo As Short, ByRef Data As Byte) As Integer
	Declare Function DioOutByte Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal PortNo As Short, ByVal Data As Byte) As Integer
	Declare Function DioOutBit Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal BitNo As Short, ByVal Data As Byte) As Integer
	Declare Function DioEchoBackByte Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal PortNo As Short, ByRef Data As Byte) As Integer
	Declare Function DioEchoBackBit Lib "CCAPDIO.DLL" (ByVal Id As Short, ByVal BitNo As Short, ByRef Data As Byte) As Integer
	Declare Function DioInpMultiByte Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef PortNo As Short, ByVal PortNum As Short, ByRef Data As Byte) As Integer
	Declare Function DioInpMultiBit Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef BitNo As Short, ByVal BitNum As Short, ByRef Data As Byte) As Integer
	Declare Function DioOutMultiByte Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef PortNo As Short, ByVal PortNum As Short, ByRef Data As Byte) As Integer
	Declare Function DioOutMultiBit Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef BitNo As Short, ByVal BitNum As Short, ByRef Data As Byte) As Integer
	Declare Function DioEchoBackMultiByte Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef PortNo As Short, ByVal PortNum As Short, ByRef Data As Byte) As Integer
	Declare Function DioEchoBackMultiBit Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef BitNo As Short, ByVal BitNum As Short, ByRef Data As Byte) As Integer
	Declare Function DioGetMaxPorts Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef InPortNum As Short, ByRef OutPortNum As Short) As Integer
	Declare Function DioGetMaxBits Lib "CCAPDIO.DLL" (ByVal Id As Short, ByRef InBitNum As Short, ByRef OutBitNum As Short) As Integer

End Module