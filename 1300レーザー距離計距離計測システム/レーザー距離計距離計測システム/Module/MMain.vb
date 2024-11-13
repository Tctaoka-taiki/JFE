'*******************************************************************************
' @(h)  MMain.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  グローバル変数
'*******************************************************************************
Imports System.Data.Odbc
Imports Oracle.DataAccess.Client
Module MMain
    ''ID
    Public gstrID As String '端末ID

    ''機械NO
    Public gstr機械NO As String '選択されている機械NO
    ''担当者CD
    Public gstr担当者CD As String '選択されている直(担当者CD)

    ''処理中加工
    Public gstr加工NO As String = ""
    Public gstr子番 As String = ""
    Public gstrセットNO As String = ""
    Public gstrカットNO As String = ""
    Public gstr最終セットカット As String = ""
    Public gstr最初セットカット As String = ""


    ''起動モード
    Public gMode_メンテ As Boolean

    ''接続モード
    Public gMode_接続 As gEnm接続 = MConst.gEnm接続.ORACLE

    ''事業所コード
    Public gstr事業所コード As String

    ''実績入力画面で仕様
    'Public gcla実績 As C実績入力

    ''起因
    'Public gclaメーカ起因 As C実績入力.c実績入力_候補値
    'Public gcla社内起因 As C実績入力.c実績入力_候補値

    '''エラーログクラス
    'Public gclaLOG As New CLog

    ''ダイアログ
    'Public gDiaテンキー As dia0001_TenKey            ''フォームから呼び出すテンキー
    'Public gDiaテンキー_Dia As dia0002_TenKey_dia    ''ダイアログから呼び出すテンキー

    '''2005/08/24(K) デバッグ用
    'Public gDia作業時間登録 As dia9001_作業時間登録

    'Public gDia加工指示書発行 As dia1001_加工指示書発行
    'Public gDia検査記録表発行 As dia1002_検査記録表発行
    'Public gDiaラベル発行 As dia1003_ラベル発行
    'Public gDia機械番号選択 As dia1004_機械番号選択
    'Public gDia実貫重量入力 As dia1005_実貫重量入力
    'Public gDia障害時間入力 As dia1006_障害時間入力
    'Public gDia板厚入力 As dia1007_板厚入力
    'Public gDia端板入力 As dia1008_端板入力
    'Public gDia端板入力_詳細 As dia1009_端板入力_詳細
    'Public gDiaクレーム原因入力 As dia1010_クレーム原因入力
    'Public gDia在区入力 As dia1011_在区入力

    'Public gDiaセット変更 As dia1101_セット変更

    'Public gDia加工指示照会検索 As dia2101_加工指示照会検索

    'Public gDia品質仕様発行 As dia3101_品質仕様発行
    'Public gDia作業日報発行 As dia2201_作業日報発行
    'Public gDia副資材手配表発行 As dia2202_副資材手配表発行

    'Public gDiaクレーム履歴検索 As dia3201_クレーム履歴検索

    'Public gDia出力先選択 As dia5001_出力先選択
    'Public gDia機械登録 As dia5002_機械登録

    Public gstrPLSQLログ As String
    Public gblnPLSQL保存有 As Boolean
    Public gstrログファイル出力先 As String
    Public gblnログファイル有無 As Boolean

#Region "ダイアログ初期位置"
    Public gTop_テンキー As Integer = 518
    Public gLeft_テンキー As Integer = 866
    Public gTop_テンキー_Dia As Integer = 457
    Public gLeft_テンキー_Dia As Integer = 826
    Public gTop_加工指示書発行 As Integer = 80
    Public gLeft_加工指示書発行 As Integer = 608
    Public gTop_検査記録表発行 As Integer = 80
    Public gLeft_検査記録表発行 As Integer = 29
    Public gTop_ラベル発行 As Integer = 446
    Public gLeft_ラベル発行 As Integer = 281
    Public gTop_機械番号選択 As Integer = 60
    Public gLeft_機械番号選択 As Integer = 93
    Public gTop_実貫重量入力 As Integer = 501
    Public gLeft_実貫重量入力 As Integer = 10
    Public gTop_障害時間入力 As Integer = 171
    Public gLeft_障害時間入力 As Integer = 487
    Public gTop_板厚入力 As Integer = 56
    Public gLeft_板厚入力 As Integer = 130
    Public gTop_端板入力 As Integer = 199
    Public gLeft_端板入力 As Integer = 196
    Public gTop_端板入力_詳細 As Integer = 402
    Public gLeft_端板入力_詳細 As Integer = 198
    Public gTop_クレーム原因入力 As Integer = 201
    Public gLeft_クレーム原因入力 As Integer = 890
    Public gTop_在区入力 As Integer = 136
    Public gLeft_在区入力 As Integer = 179

    Public gTop_セット変更 As Integer = 385
    Public gLeft_セット変更 As Integer = 340

    Public gTop_加工指示照会検索 As Integer = 518
    Public gLeft_加工指示照会検索 As Integer = 866

    Public gTop_品質仕様発行 As Integer = 540
    Public gLeft_品質仕様発行 As Integer = 22
    Public gTop_作業日報発行 As Integer = 540
    Public gLeft_作業日報発行 As Integer = 22
    Public gTop_副資材手配表発行 As Integer = 400
    Public gLeft_副資材手配表発行 As Integer = 400

    Public gTop_クレーム履歴検索 As Integer = 137
    Public gLeft_クレーム履歴検索 As Integer = 62

    Public gTop_出力先選択 As Integer = 19
    Public gLeft_出力先選択 As Integer = 762
    Public gTop_機械登録 As Integer = 54
    Public gLeft_機械登録 As Integer = 481

#End Region

    ''メッセージボックス
    Public Sub gMsg_注意(ByVal strMsg As String)
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.注意, strMsg)
        'Call diaMsg.ShowDialog()
    End Sub
    Public Sub gMsg_情報(ByVal strMsg As String)
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.情報, strMsg)
        'Call diaMsg.ShowDialog()
    End Sub
    Public Sub gMsg_警告(ByVal strMsg As String)
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.警告, strMsg)
        'Call diaMsg.ShowDialog()
    End Sub

    Public Function gMsg_YesNo(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.YesNo, strMsg)
        'Return diaMsg.ShowDialog()
    End Function
    Public Function gMsg_YesNoCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        'Dim diaMsg As New dia0000_MSGBOX(dia0000_MSGBOX.MsgType.YesNoCancel, strMsg)
        'Return diaMsg.ShowDialog
    End Function

    Public Function gInt(ByVal strInt As String) As Integer
        If strInt.TrimEnd = "" Then
            Return 0
        ElseIf IsNumeric(strInt) = False Then
            Return 0
        Else
            Return CInt(strInt)
        End If
    End Function
    Public Function gDbl(ByVal strInt As String) As Double
        If strInt.TrimEnd = "" Then
            Return 0
        ElseIf IsNumeric(strInt) = False Then
            Return 0
        Else
            Return CDbl(strInt)
        End If
    End Function

    ''日付変換関数8桁に/をつける-------------------------------------------------------------------------------------------------
    Public Function gStrFormat日付(ByVal str日付 As String) As String
        Dim strBuff As String
        If str日付.Length <> 8 Then
            Return str日付
        Else
            strBuff = str日付.Substring(0, 4) & "/" & str日付.Substring(4, 2) & "/" & str日付.Substring(6, 2)
            Return strBuff
        End If
    End Function
    '14桁をCdateにかえれるかたちにする
    Public Function gStrFormat日時(ByVal str日時 As String) As String
        Dim strBuff As String
        If str日時.Length <> 14 Then
            Return str日時
        Else
            strBuff = str日時.Substring(0, 4) & "/" & str日時.Substring(4, 2) & "/" & str日時.Substring(6, 2) & " " & str日時.Substring(8, 2) & ":" & str日時.Substring(10, 2) & ":" & str日時.Substring(12, 2)
            Return strBuff
        End If
    End Function

End Module
