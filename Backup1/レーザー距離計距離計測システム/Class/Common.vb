Imports System.Windows.Forms
Public Class Common

    ''エラーログクラス
    'Public gclaLOG As New CLog(CLog.Enmログ種別.アプリケーション)

    Public Enum gEnm_作業状況
        入庫
        出庫
        払出
        移動
    End Enum

    Public Shared gStr端末名 As String = MFile.gStrParameterStr("端末名", "COIL")
    Public Shared gStr工場ID As String = MFile.gStrParameterStr("工場ID", "C1")

    Public Enum gEnm_システム終了
        SHUTDOWN_OFF
        SHUTDOWN_ON
    End Enum
    Public Shared gシステム終了 As gEnm_システム終了 = CInt(MFile.gStrParameterStr("SHUTDOWN", "1"))

    Public Shared g出庫在庫削除期間 As Integer = CInt(MFile.gStrParameterStr("出庫在庫削除期間", "3"))

    Public Shared gMODE As Integer = CInt(MFile.gStrParameterStr("MODE", "0"))

    Public Shared gRFID_MODE As Integer = CInt(MFile.gStrParameterStr("RFID_MODE", "0"))

    Public Shared gDIO_MODE As Integer = CInt(MFile.gStrParameterStr("DIO_MODE", "0"))
    Public Shared gPar_作業状況 As gEnm_作業状況

    'Public Shared gPar_払出データ As C払出データ
    'Public Shared gPar_受入データ As C受入データ

    ''メッセージボックス
    Public Shared Sub gMsg_注意(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Shared Sub gMsg_警告(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub gMsg_情報(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Function gMsg_YesNo(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Public Shared Function gMsg_YesNoCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
    End Function

    Public Shared Function gWrtLog_Operation(ByVal strMsg As String, Optional ByVal intLogLv As Integer = 0) As Boolean
        'Dim claSQL As New CSql
        'Dim lBlnRet As Boolean = False

        'Try
        '    With claSQL
        '        .gSubClearSQL()
        '        .pSQLTYPE = CSql.SQL_TYPE.SQL_INSERT
        '        .pStrTable = "TL_OperationLog"

        '        .gSubColumnValue("固有番号", "SQ_TL_OperationLog.NEXTVAL", False)
        '        .gSubColumnValue("ログレベル", intLogLv, False)
        '        .gSubColumnValue("ログ内容", strMsg, True)

        '        If Common.gclaODP.gBlnExeCute(.gStrSQL, False) Then
        '            lBlnRet = True
        '        End If
        '    End With

        '    Return lBlnRet

        'Catch ex As Exception
        '    Common.gMsg_警告(ex.ToString)
        'End Try
    End Function

End Class
