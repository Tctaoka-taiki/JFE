'*******************************************************************************
' @(h)  MFile.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  ファイル操作関連関数
'*******************************************************************************
Imports System.IO
Imports System.Windows.Forms

Module MFile

#Region "設定ファイルデータ読込（文字列データ）"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：設定ファイルデータ読込（文字列データ）
    ' 引　数　：strKeyName      キー名
    ' 　　　　　strDefault      デフォルト値
    ' 戻り値　：strParam        取得パラメータ
    ' 機能説明：設定ファイルから文字列データを読み込む。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gStrParameterStr(ByVal strKeyName As String, Optional ByVal strDefault As String = "") As String
        Dim strParm As String
        Try
            Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

            strParm = CType(configurationAppSettings.GetValue(strKeyName, GetType(System.String)), String)
            ''取得できない時はデフォルトを返す
        Catch exOpe As InvalidOperationException
            strParm = strDefault
        End Try

        Return strParm
    End Function

#Region "ファイル読み込み"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：CSV出力
    ' 引　数　：objCollection コレクション
    ' 戻り値　：
    ' 機能説明：ファイルを開き内容を1行づつコレクションに格納します
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub iSubFileRead(ByRef objCollection As Collection)
        Dim diaFile As New OpenFileDialog

        ''ファイルダイアログ
        diaFile.Filter = "csv files (*.csv)|*.csv"
        If diaFile.ShowDialog() = DialogResult.OK Then
            Call Application.DoEvents()

            Dim sr As New StreamReader(diaFile.FileName, System.Text.Encoding.GetEncoding(932))
            Try
                '内容を一行ずつ読み込む
                While sr.Peek() > -1
                    objCollection.Add(sr.ReadLine())
                End While
            Finally
                '閉じる
                sr.Close()
            End Try
        End If
    End Sub

#Region "ファイル名取得"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：ファイル名取得
    ' 引　数　：strFilter       フィルタ設定文字列
    '           strFileName     ファイル名デフォルト値
    ' 戻り値　：blnRslt         処理結果
    '           strFileName     ファイル名
    ' 機能説明：ファイル名指定ダイアログを表示し、ファイル名を返す。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnファイル名取得(ByRef strFileName As String, ByVal strDirectory As String, ByVal strFilter As String) As Boolean
        Dim objFileDialog As New OpenFileDialog

        With objFileDialog
            ''ファイルフィルタ設定
            .Filter = strFilter
            ''初期ファイル名設定
            .FileName = strFileName
            ''初期ディレクトリ設定
            If strDirectory.Length = 0 Then strDirectory = Application.StartupPath
            .InitialDirectory = strDirectory

            ''ファイル指定ダイアログ表示
            If .ShowDialog() = DialogResult.OK Then
                Call Application.DoEvents()

                ''指定ファイル名格納
                strFileName = .FileName

                Return True
            End If
        End With
        objFileDialog = Nothing

    End Function

#Region "Logファイルの一行書込み"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Logファイルの一行書込み処理
    ' 引　数　：書込み文字列
    ' 戻り値　：結果
    ' 機能説明：Logファイルの一行書込み処理
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnLogFileLineWrite(ByVal strPram As String, ByVal strPath As String, ByVal blnAdd As Boolean) As Boolean

        If strPram Is Nothing Then
            Exit Function
        End If

        ''ファイルを上書きし、Shift JISで書き込む
        Dim sysLine As System.IO.StreamWriter

        Try

            ''ファイルを上書きし、Shift JISで書き込む
            sysLine = New System.IO.StreamWriter(strPath, blnAdd, System.Text.Encoding.GetEncoding(932))

            ''書込み
            sysLine.WriteLine(strPram)
            Return True
        Finally
            If Not sysLine Is Nothing Then
                sysLine.Close()
            End If
        End Try

    End Function

#Region "Logファイルの一行読込み"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Logファイルの一行書込み処理
    ' 引　数　：書込み文字列
    ' 戻り値　：結果
    ' 機能説明：Logファイルの一行書込み処理
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gStrLogFileLineRead(ByVal strPath As String) As String

        ''ファイルを上書きし、Shift JISで書き込む
        Dim sysLine As System.IO.StreamReader

        Try

            ''ファイルを上書きし、Shift JISで書き込む
            sysLine = New System.IO.StreamReader(strPath, System.Text.Encoding.GetEncoding(932))

            ''読込み（結果を返す）
            Return CType(sysLine.ReadLine(), String)

        Finally
            If Not sysLine Is Nothing Then
                sysLine.Close()
            End If
        End Try

    End Function

#Region "Logファイル読み込み"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：CSV出力
    ' 引　数　：objCollection コレクション
    ' 戻り値　：
    ' 機能説明：ファイルを開き内容を1行づつコレクションに格納します
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubFileRead(ByRef objCollection As Collection, ByVal strPath As String)

        ''ファイルダイアログ

        Dim key As Integer = 0
        Dim sr As New StreamReader(strPath, System.Text.Encoding.GetEncoding(932))
        Try
            '内容を一行ずつ読み込む
            While sr.Peek() > -1
                'objCollection.Add(sr.ReadLine(), CStr(key))
                'If Not sr.ReadLine().Trim = "" Then
                objCollection.Add(sr.ReadLine())
                key += 1
                'End If

            End While
        Finally
            '閉じる
            sr.Close()
        End Try

    End Sub

#Region "ファイルの検索"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Logファイルの一行書込み処理
    ' 引　数　：書込み文字列
    ' 戻り値　：結果
    ' 機能説明：Logファイルの一行書込み処理
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnFileEixstChk(ByVal strPath As String) As Boolean

        'ファイルの存在を確認する
        '存在すればTrueを返す 
        If File.Exists(strPath) = True Then
            Return True
        Else
            Return False
        End If

    End Function

#Region "ファイルの取得"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Logファイルの一行書込み処理
    ' 引　数　：書込み文字列
    ' 戻り値　：結果
    ' 機能説明：Logファイルの一行書込み処理
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gStrFileGet(ByVal strPath As String) As String()
        Dim files As String() = System.IO.Directory.GetFiles(strPath, "*", SearchOption.AllDirectories)

        Return files
    End Function

End Module
