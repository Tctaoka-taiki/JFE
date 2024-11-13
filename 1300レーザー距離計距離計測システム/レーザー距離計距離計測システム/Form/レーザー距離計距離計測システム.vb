Imports System.IO
Imports System.Windows.Forms
Imports System.Collections


Public Class レーザー距離計距離計測システム

    Public Shared objMutex As System.Threading.Mutex

    ''制御用変数 ------------------------------------------------------------------------------------------------------

    ''機器ID　（各変数のキー情報の参照に用いる）
    Private mstr機器ID_7 As String() = {"STXY7", "STZD7", "X7", "Y7", "Z7", "D7"}
    Private mstr機器ID_8 As String() = {"STXY8", "STZD8", "X8", "Y8", "Z8", "D8"}
    Private mstr機器ID_9 As String() = {"STXY9", "STZD9", "X9", "Y9", "Z9", "D9"}

    Private Const mcon機器ID_ST_S As Short = 0   'INDEX（無線ステーションSTART）
    Private Const mcon機器ID_ST_E As Short = 1   'INDEX（無線ステーションEND）
    Private Const mcon機器ID_RK_S As Short = 2   'INDEX（距離計START）
    Private Const mcon機器ID_RK_E As Short = 4   'INDEX（距離計END）
    Private Const mcon機器ID_DI As Short = 5     'INDEX（機器ID）


    ''機器CHKID　（画面表示用コントロールの参照に用いる）
    Private mstr機器CHKID As String() = {"接続_X", "接続_Y", "接続_Z", "接続_D", _
                                         "接続_ST1X", "接続_ST1Y", "接続_ST2Z", "接続_ST2D", _
                                         "COM_X", "COM_Y", "COM_Z", "COM_D", _
                                         "RK_X", "RK_Y", "RK_Z", "DI_POW", "DI_TNG", _
                                         "DATA_X", "DATA_Y", "DATA_Z", "DATA_POW", "DATA_TNG"}

    Private Const mcon機器CHKID_DATA_S As Short = 17  'INDEX（取得データ表示用コントロールSTART）
    Private Const mcon機器CHKID_DATA_E As Short = 21  'INDEX（取得データ表示用コントロールEND）


    ''コレクション変数 ------------------------------------------------------------------------------------------------------

    ''【クラスオブジェクト用】

    ''レーザー距離計 (距離計：SICK DME3000-311S15)
    Private mColCls距離計 As Collection
    ''デジタル入出力 (IO：CONTEC CPU-XXXXXXXX  Module-DIO(8/8)-FG)
    Private mColClsD入力 As Collection

    ''【TMPデータ用】
    Private mhstRKデータ As Hashtable            ''距離データ
    Private mhstRKデータ_CHK As Hashtable        ''距離データ（チェック用）
    Private mhstDIデータ_CORR As Hashtable       ''DIデータ（今回取得分）
    Private mhstDIデータ_PREV As Hashtable       ''DIデータ（前回取得分）
    Private mhstDIデータ_CHK As Hashtable        ''DIデータ（チェック用）


    ''【システム変数用】
    Private mhst機器IP As Hashtable              ''機器IP
    Private mhstDIPort As Hashtable              ''DIポート
    Private mhstMSG機器名 As Hashtable           ''メッセージ表示用機器名称
    Private mstrSYSMODE As String                ''システムモード("0":MANUAL "1":TEST)

    '↓20130118Morimoto
    Private mstrLOGMODE As String                   ''ログモード("0":無 "1":有)
    '↑20130118Morimoto

    '↓20130130Morimoto
    Private mBlnファイル書込要求 As Boolean         ''ファイル書き込み要求("0":無 "1":有)
    Private mstr電源変化有無 As String              ''電源変化有無("0":無 "1":有)
    Private mstr開閉状態 As String                  ''開閉状態("0":開 "1":閉)
    '↑20130130Morimoto

    Private Const mconLANリトライ回数 As Integer = 5 ''LANリトライ
    Private Const mconRKリトライ回数 As Integer = 5 ''LANリトライ

    ''【コントロール用】
    ''機器CHK表示用コントロール
    Private mColCtl機器CHK表示 As Collection


    ''処理結果変数 --------------------------------------------------------------------------------------------------------

    ''DI初回監視判定
    Private mbln初回取得_7 As Boolean = True
    Private mbln初回取得_8 As Boolean = True
    Private mbln初回取得_9 As Boolean = True

    ''DIPIng監視判定   2007/10/22 inoue ★トング取り外し対応
    Private mblnPing監視MODE_7 As Boolean = False
    Private mblnPing監視MODE_8 As Boolean = False
    Private mblnPing監視MODE_9 As Boolean = False

    ''txt計測履歴格納
    Private mstr計測履歴_7 As String = ""
    Private mstr計測履歴_8 As String = ""
    Private mstr計測履歴_9 As String = ""

    ''表示用CTL格納buff
    Private mstr計測CTLbuff_7 As String() = {"YYYY/MM/DD HH:MM:SS", "YYYYMMDD9999.txt", "999999", "999999", "999999", "開"}
    Private mstr計測CTLbuff_8 As String() = {"YYYY/MM/DD HH:MM:SS", "YYYYMMDD9999.txt", "999999", "999999", "999999", "開"}
    Private mstr計測CTLbuff_9 As String() = {"YYYY/MM/DD HH:MM:SS", "YYYYMMDD9999.txt", "999999", "999999", "999999", "開"}

    'ファイル設定用
    Private mstrFileDir計測DATA_7 As String = ""   ''計測データファイル保存ディレクトリ
    Private mstrFileDir計測DATA_8 As String = ""   ''計測データファイル保存ディレクトリ
    Private mstrFileDir計測DATA_9 As String = ""   ''計測データファイル保存ディレクトリ
    Private mstrFileDir計測履歴_7 As String = ""   ''計測履歴ファイル保存ディレクトリ
    Private mstrFileDir計測履歴_8 As String = ""   ''計測履歴ファイル保存ディレクトリ
    Private mstrFileDir計測履歴_9 As String = ""   ''計測履歴ファイル保存ディレクトリ

    Private mintFile連番_7 As Integer = 0          ''連番管理（左記連番をファイル名に含む）
    Private mintFile連番_8 As Integer = 0          ''連番管理（左記連番をファイル名に含む）
    Private mintFile連番_9 As Integer = 0          ''連番管理（左記連番をファイル名に含む）

    Private mstrFile日付 As String = ""            ''本日日付（左記日付をファイル名に含む）

    Private mstrdiarst As DialogResult

    Private mRecnt_CheckDevice As Integer = 0      ''リトライ回数（機器チェック）    2008/4/30 Inoue Add (Ver.1.0.0.2)
    Private mReCnt_ReadLenData As Integer = 0      ''リトライ回数（距離データ取得）  2008/4/30 Inoue Add (Ver.1.0.0.2)
    Private mReIntvl_CheckDevice As Integer = 0    ''リトライ間隔（機器チェック）    2008/4/30 Inoue Add (Ver.1.0.0.2)
    Private mReIntvl_ReadLenData As Integer = 0    ''リトライ間隔（距離データ取得）  2008/4/30 Inoue Add (Ver.1.0.0.2)
    Private mStrReplaceLendata As String = "999999" ''距離データ不正時の置換戻り値   2008/4/28 Inoue Add (Ver.1.0.0.2)

    ''列挙型 -------------------------------------------------------------------------------------------------------------

    ''機器区分
    Private Enum mEnm機器区分
        RK   ''距離計      （RazorKei）
        DI   ''デジタル入力（DegitalInput）
        ST   ''無線ｽﾃｰｼｮﾝ  （Station）
    End Enum

    ''機器チェック結果
    Private Enum mEnmCHK区分
        LAN
        COM
        DAT
    End Enum

    ''DIデータ区分
    Private Enum mEnmDIDATA区分
        POW
        TNG
    End Enum

    ''倉庫選択
    Private Enum mEnm倉庫区分
        第７倉庫
        第８倉庫
        第９倉庫
    End Enum

    ''フォームロード -------------------------------------------------------------------

    Private Sub レーザー距離計距離計測システム_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''変数宣言
        Dim rtnbln As Boolean = True ''戻り値
        Dim i As Integer = 0         ''2008/4/30 Inoue Add (ver.1.0.0.2)

        ''変数初期設定 ------------------------------------------------------------------------------------

        '２重起動チェック
        If Not Me.mbln起動済チェック() Then
            ''起動済
            Call MessageBox.Show("すでに起動済みです。", "処理エラーメッセージ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        Call Me.mSub設定ファイル読込()    ''2008/4/30 Inoue Add (Ver.1.0.0.2)

        Call Me.mSubColinit()             ''Collectionの初期設定

        Call Me.mSubファイル設定init()    ''ファイルの初期設定

        Call Me.mSub時刻設定init()        ''時刻の初期設定

        Call Me.mSubスレッド設定init()    ''スレッドの初期設定

        Call Me.mSub機器制御用インスタンス生成(mEnm倉庫区分.第７倉庫)  ''機器制御クラスインスタンス生成

        ''接続機器チェック --------------------------------------------------------------------------------

        ''リトライ処理を追加  2008/4/30 Inoue Add (ver.1.0.0.2)
        For i = 1 To Me.mRecnt_CheckDevice
            rtnbln = mbln接続チェック(mEnm倉庫区分.第７倉庫)
            If rtnbln Then
                Exit For
            End If
            ''待機(default:2000)
            System.Threading.Thread.Sleep(Me.mReIntvl_CheckDevice)
        Next

        ''表示
        If rtnbln Then
            Me.mSub機器状況SET(False, MConst.MSG_CHK_OK)
            ''信号監視ON
            Me.tmr7.Enabled = True
            Me.mSub機器状況SET(True, "信号監視を開始しました。")   ''メッセージ表示
        Else
            ''メッセージボックス表示
            MessageBox.Show("機器の接続チェックに失敗しました。" & vbCrLf & _
                            "詳細は機器状況を参照下さい。", _
                            "処理エラーメッセージ", _
                             MessageBoxButtons.OK, MessageBoxIcon.Error)

            ''信号監視OFF
            Me.tmr7.Enabled = False
            Me.mSub機器状況SET(True, "信号監視を停止しました。")   ''メッセージ表示

            ''スクロールバー制御
            Call Me.mSubScrollToCaret(Me.txt機器状況, False)

            ''システムSTS更新
            Me.SLblシステム状態.Text = "オフライン"

        End If
    End Sub

#Region "起動済チェック"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：起動チェック
    ' 戻り値　：True 起動済　False 起動済でない
    ' 引　数　：なし
    ' 機能説明：既に起動済かどうかのチェックを行う。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Function mbln起動済チェック() As Boolean


        ''起動済の場合は終了
        objMutex = New System.Threading.Mutex(False, "MyName")
        ''ミューテックスの所有権の要求
        If objMutex.WaitOne(0, False) = False Then
            ''起動済
            Return False
        End If

        Return True
    End Function

#Region "設定ファイル読込"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：設定ファイル読込
    ' 戻り値　：なし
    ' 引　数　：なし
    ' 機能説明：App.configファイルのパラメータを取得する
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    ''2008/4/30 Inoue Add (Ver.1.0.0.2)
    Private Sub mSub設定ファイル読込()

        Me.mRecnt_CheckDevice = CType(MFile.gStrParameterStr("ReCnt_CheckDevice", "3"), Integer)  'リトライ回数（機器チェック） 2008/04/28 Inoue Add (Ver.1.0.0.2)
        Me.mReCnt_ReadLenData = CType(MFile.gStrParameterStr("ReCnt_ReadLenData", "3"), Integer)  'リトライ回数（距離データ取得） 2008/04/28 Inoue Add (Ver.1.0.0.2)
        Me.mReIntvl_CheckDevice = CType(MFile.gStrParameterStr("ReInterval_CheckDevice", "2000"), Integer)  'リトライ間隔（機器チェック） 2008/04/28 Inoue Add (Ver.1.0.0.2)
        Me.mReIntvl_ReadLenData = CType(MFile.gStrParameterStr("ReInterval_ReadLenData", "100"), Integer)  'リトライ間隔（距離データ取得） 2008/04/28 Inoue Add (Ver.1.0.0.2)
        mStrReplaceLendata = MFile.gStrParameterStr("Replace_lendata", "999999")  '2008/04/28 Inoue Add (Ver.1.0.0.2)
    End Sub


    ''Collectionの初期設定
    Private Sub mSubColinit()

        ''インスタンス生成 ---------------------------------------

        'Collection
        Me.mColCls距離計 = New Collection
        Me.mColClsD入力 = New Collection
        Me.mColCtl機器CHK表示 = New Collection
        'Hashtable
        Me.mhstRKデータ = New Hashtable
        Me.mhstDIデータ_CORR = New Hashtable
        Me.mhstDIデータ_PREV = New Hashtable
        Me.mhstDIデータ_CHK = New Hashtable

        Me.mhst機器IP = New Hashtable
        Me.mhstDIPort = New Hashtable
        Me.mhstMSG機器名 = New Hashtable

        ''データ登録 -------------------------------------------------------------------------------

        ''mColCls距離計 / mColClsD入力
        'インスタンス生成Sub内でデータ登録を行う

        ''mColCtl機器CHK表示 （キー：機器CHKID）----------------------------------------------------
        '接続結果
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKX, Me.mstr機器CHKID(0))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKY, Me.mstr機器CHKID(1))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKZ, Me.mstr機器CHKID(2))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKD1, Me.mstr機器CHKID(3))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKST1_X, Me.mstr機器CHKID(4))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKST1_Y, Me.mstr機器CHKID(5))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKST2_Z, Me.mstr機器CHKID(6))
        Me.mColCtl機器CHK表示.Add(Me.lbl接続CHKST2_D1, Me.mstr機器CHKID(7))
        'COM結果
        Me.mColCtl機器CHK表示.Add(Me.LblCOMCHKX, Me.mstr機器CHKID(8))
        Me.mColCtl機器CHK表示.Add(Me.LblCOMCHKY, Me.mstr機器CHKID(9))
        Me.mColCtl機器CHK表示.Add(Me.LblCOMCHKZ, Me.mstr機器CHKID(10))
        Me.mColCtl機器CHK表示.Add(Me.LblCOMCHKD1, Me.mstr機器CHKID(11))
        'データ結果
        Me.mColCtl機器CHK表示.Add(Me.lblDataRKX, Me.mstr機器CHKID(12))
        Me.mColCtl機器CHK表示.Add(Me.lblDataRKY, Me.mstr機器CHKID(13))
        Me.mColCtl機器CHK表示.Add(Me.lblDataRKZ, Me.mstr機器CHKID(14))
        Me.mColCtl機器CHK表示.Add(Me.lblD入力電源, Me.mstr機器CHKID(15))
        Me.mColCtl機器CHK表示.Add(Me.lblD入力トングSTS, Me.mstr機器CHKID(16))
        'データ
        Me.mColCtl機器CHK表示.Add(Me.lblDataX軸CHK, Me.mstr機器CHKID(17))
        Me.mColCtl機器CHK表示.Add(Me.lblDataY軸CHK, Me.mstr機器CHKID(18))
        Me.mColCtl機器CHK表示.Add(Me.lblDataZ軸CHK, Me.mstr機器CHKID(19))
        Me.mColCtl機器CHK表示.Add(Me.lblData入力電源, Me.mstr機器CHKID(20))
        Me.mColCtl機器CHK表示.Add(Me.lblData入力トングSTS, Me.mstr機器CHKID(21))

        ''倉庫別の初期設定

        Call Me.mSubColinit_倉庫別(mEnm倉庫区分.第７倉庫)
        '★Call Me.mSubColinit_倉庫別(mEnm倉庫区分.第８倉庫)
        '★Call Me.mSubColinit_倉庫別(mEnm倉庫区分.第９倉庫)

        ''test用
        Me.mstrSYSMODE = MFile.gStrParameterStr("SYSMODE", "0")

        '↓20130118Morimoto
        Me.mstrLOGMODE = MFile.gStrParameterStr("LOGMODE", "0")
        '↑20130118Morimoto

        'test用コントロールの表示
        If Me.mstrSYSMODE = "0" Then
            GroupBox4.Visible = False
        Else
            GroupBox4.Visible = True
        End If


    End Sub

    Private Sub mSubColinit_倉庫別(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim str機器ID As String()   ''機器IDbuff
        Dim i As Integer            ''ループ制御
        Dim strIP As String         ''IPアドレスbuff
        Dim shtP_POW As Short       ''電源信号ポートbuff
        Dim shtP_TNG As Short       ''ﾄﾝｸﾞ信号ポートbuff

        str機器ID = mstr機器ID選択(enm倉庫区分)

        'mhst計測データbuff（RKのみ キー：機器ID）------------------------
        For i = mcon機器ID_RK_S To mcon機器ID_RK_E
            Me.mhstRKデータ.Add(str機器ID(i), "")
        Next

        'mhstDIデータbuff（DIのみ キー：機器ID）------------------------------ 
        Me.mhstDIデータ_CORR.Add("INPOW_" & str機器ID(mcon機器ID_DI), "0")
        Me.mhstDIデータ_CORR.Add("INTNG_" & str機器ID(mcon機器ID_DI), "0")
        Me.mhstDIデータ_PREV.Add("INPOW_" & str機器ID(mcon機器ID_DI), "0")
        Me.mhstDIデータ_PREV.Add("INTNG_" & str機器ID(mcon機器ID_DI), "0")
        Me.mhstDIデータ_CHK.Add("INPOW_" & str機器ID(mcon機器ID_DI), "0")
        Me.mhstDIデータ_CHK.Add("INTNG_" & str機器ID(mcon機器ID_DI), "0")

        'mhstDIPort（DIのみ キー：機器ID） -----------------------------------
        shtP_POW = CShort(MFile.gStrParameterStr("INPOW_" & str機器ID(mcon機器ID_DI), "0"))
        shtP_TNG = CShort(MFile.gStrParameterStr("INTNG_" & str機器ID(mcon機器ID_DI), "1"))
        Me.mhstDIPort.Add("INPOW_" & str機器ID(mcon機器ID_DI), shtP_POW)
        Me.mhstDIPort.Add("INTNG_" & str機器ID(mcon機器ID_DI), shtP_TNG)

        'mhst機器IP（全機器 キー：機器ID）--------------------------------------------
        For i = 0 To str機器ID.Length - 1
            strIP = MFile.gStrParameterStr("IP_" & str機器ID(i), "255.255.255.255")  'IP取得
            Me.mhst機器IP.Add(str機器ID(i), strIP) 'Hst登録
        Next

        'mhstMSG用機器名（全機器 キー：機器ID） --------------------------------------
        Me.mhstMSG機器名.Add(str機器ID(0), "無線ステーション(XY軸用)")
        Me.mhstMSG機器名.Add(str機器ID(1), "無線ステーション(ZD軸用)")
        Me.mhstMSG機器名.Add(str機器ID(2), "距離計(X軸用)")
        Me.mhstMSG機器名.Add(str機器ID(3), "距離計(Y軸用)")
        Me.mhstMSG機器名.Add(str機器ID(4), "距離計(Z軸用)")
        Me.mhstMSG機器名.Add(str機器ID(5), "入力信号モジュール")

    End Sub

    ''ファイル操作 ---------------------------------------------------------------------

    Private Sub mSubファイル設定init()

        ''計測データファイル用
        Me.mstrFileDir計測DATA_7 = MFile.gStrParameterStr("filepath_計測_7", "C:\XYZ-DATA")
        Me.mstrFileDir計測DATA_8 = MFile.gStrParameterStr("filepath_計測_8", "C:\XYZ-DATA")
        Me.mstrFileDir計測DATA_9 = MFile.gStrParameterStr("filepath_計測_9", "C:\XYZ-DATA")
        ''計測履歴データファイル用(StartupPath配下)
        Me.mstrFileDir計測履歴_7 = Application.StartupPath & MFile.gStrParameterStr("filepath_履歴_7", "\log\")
        Me.mstrFileDir計測履歴_8 = Application.StartupPath & MFile.gStrParameterStr("filepath_履歴_8", "\log\")
        Me.mstrFileDir計測履歴_9 = Application.StartupPath & MFile.gStrParameterStr("filepath_履歴_9", "\log\")
        ''日付（ファイル名）
        mstrFile日付 = Format(Now, "yyyyMMdd")

        ''不要ファイル削除
        Call Me.mSub不要ファイル削除(mEnm倉庫区分.第７倉庫)
        ''連番処理の初期値
        Call Me.mSubファイル連番init(mEnm倉庫区分.第７倉庫)
        ''計測履歴ファイル展開の初期値
        Call Me.mSub計測履歴ファイル処理(mEnm倉庫区分.第７倉庫)

    End Sub

    Private Sub mSubファイル連番init(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim strFN As String         ''ファイル名
        Dim strID As String = ""    ''識別ID
        Dim strRead As String = ""  ''読取結果

        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                strID = "7"
            Case mEnm倉庫区分.第８倉庫
                strID = "8"
            Case mEnm倉庫区分.第９倉庫
                strID = "9"
        End Select

        ''ファイル名
        strFN = Me.mstrFileDir計測履歴_7 & "Ren" & strID & "_" & Me.mstrFile日付 & ".txt"

        ''ファイル検索

        If MFile.gBlnFileEixstChk(strFN) Then  ''ファイルあり

            ''データ読込
            strRead = MFile.gStrLogFileLineRead(strFN)

            ''読込みデータをセット
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.mintFile連番_7 = CType(strRead, Integer)
                Case mEnm倉庫区分.第８倉庫
                    Me.mintFile連番_8 = CType(strRead, Integer)
                Case mEnm倉庫区分.第９倉庫
                    Me.mintFile連番_9 = CType(strRead, Integer)
            End Select
        Else                                   ''ファイルなし
            ''初期値(1)をセット
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.mintFile連番_7 = 1
                Case mEnm倉庫区分.第８倉庫
                    Me.mintFile連番_8 = 1
                Case mEnm倉庫区分.第９倉庫
                    Me.mintFile連番_9 = 1
            End Select
        End If

    End Sub

    Private Sub mSubファイル連番保存(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim strFN As String         ''ファイル名
        Dim strID As String = ""    ''識別ID
        Dim intWrite As Integer = 0 ''書込データ

        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                strID = "7"
                intWrite = Me.mintFile連番_7
            Case mEnm倉庫区分.第８倉庫
                strID = "8"
                intWrite = Me.mintFile連番_8
            Case mEnm倉庫区分.第９倉庫
                strID = "9"
                intWrite = Me.mintFile連番_9
        End Select

        ''ファイル名
        strFN = Me.mstrFileDir計測履歴_7 & "Ren" & strID & "_" & Me.mstrFile日付 & ".txt"
        ''書込み
        MFile.gBlnLogFileLineWrite(CStr(intWrite), strFN, False)

    End Sub

    Private Sub mSub計測履歴ファイル保存(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim i As Integer                     ''ループ制御
        Dim strFN As String                  ''ファイル名
        Dim strID As String = ""             ''識別ID
        Dim strWrite As String = ""          ''読取結果

        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                strID = "7"
            Case mEnm倉庫区分.第８倉庫
                strID = "8"
            Case mEnm倉庫区分.第９倉庫
                strID = "9"
        End Select

        '【表示】計測データを計測履歴へ追加
        Call Me.mSub計測履歴SET()

        ''未登録時は作成しない
        If Not Me.txt計測履歴.Text.Trim = "" Then

            ''書込みデータセット
            strWrite = Me.txt計測履歴.Text
            ''ファイル名
            strFN = Me.mstrFileDir計測履歴_7 & "Log" & strID & "_" & Me.mstrFile日付 & ".txt"
            ''書込み
            MFile.gBlnLogFileLineWrite(strWrite, strFN, False)

        End If

    End Sub

    Private Sub mSub計測履歴ファイル処理(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim i As Integer                     ''ループ制御
        Dim strFN As String                  ''ファイル名
        Dim strID As String = ""             ''識別ID
        Dim strRead As String = ""           ''読取結果
        Dim objCollection As New Collection  ''読込データ格納

        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                strID = "7"
            Case mEnm倉庫区分.第８倉庫
                strID = "8"
            Case mEnm倉庫区分.第９倉庫
                strID = "9"
        End Select

        ''ファイル名
        strFN = Me.mstrFileDir計測履歴_7 & "Log" & strID & "_" & Me.mstrFile日付 & ".txt"

        ''ファイル検索
        If MFile.gBlnFileEixstChk(strFN) Then  ''ファイルあり
            '読込み
            Call MFile.gSubFileRead(objCollection, strFN)
            '展開
            For i = 1 To objCollection.Count - 1

                If i > 1 Then
                    Call Me.mSub計測履歴ファイル展開(enm倉庫区分, CStr(objCollection.Item(i)), False)  '一行づつ処理
                Else
                    Call Me.mSub計測履歴ファイル展開(enm倉庫区分, CStr(objCollection.Item(i)), True)  '一行づつ処理
                End If
            Next

            ''txt計測履歴セット
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.txt計測履歴.Text = Me.mstr計測履歴_7
                Case mEnm倉庫区分.第８倉庫
                    Me.txt計測履歴.Text = Me.mstr計測履歴_8
                Case mEnm倉庫区分.第９倉庫
                    Me.txt計測履歴.Text = Me.mstr計測履歴_9
            End Select

        Else     ''ファイルなし
            ''NULL
        End If

    End Sub

    Private Sub mSub計測履歴ファイル展開(ByVal enm倉庫区分 As mEnm倉庫区分, ByVal strbuff As String, ByVal blnCTL As Boolean)

        If blnCTL Then
            ''txt計測履歴へセット
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.mSub計測表示CTLSET(enm倉庫区分, Me.mstr計測CTLbuff_7, strbuff)
                Case mEnm倉庫区分.第８倉庫
                    Me.mSub計測表示CTLSET(enm倉庫区分, Me.mstr計測CTLbuff_8, strbuff)
                Case mEnm倉庫区分.第９倉庫
                    Me.mSub計測表示CTLSET(enm倉庫区分, Me.mstr計測CTLbuff_9, strbuff)
            End Select
        Else

            ''txt計測履歴へセット
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.mstr計測履歴_7 = Me.mstr計測履歴_7 & strbuff & vbCrLf
                Case mEnm倉庫区分.第８倉庫
                    Me.mstr計測履歴_8 = Me.mstr計測履歴_8 & strbuff & vbCrLf
                Case mEnm倉庫区分.第９倉庫
                    Me.mstr計測履歴_9 = Me.mstr計測履歴_9 & strbuff & vbCrLf
            End Select
        End If


    End Sub
    ''計測表示用コントロールへのデータセット
    Private Sub mSub計測表示CTLSET(ByVal enm倉庫区分 As mEnm倉庫区分, ByRef strbuff As String(), ByVal strbuff2 As String)

        ''表示用コントロールへセット
        If strbuff2.Length = 83 Then
            strbuff(0) = strbuff2.Substring(0, 19)   ''時刻
            strbuff(1) = strbuff2.Substring(23, 16)   ''ファイル名
            strbuff(2) = strbuff2.Substring(46, 6)   ''X軸
            strbuff(3) = strbuff2.Substring(57, 6)   ''Y軸
            strbuff(4) = strbuff2.Substring(68, 6)   ''Z軸

            If strbuff2.Substring(82, 1) = "開" Then
                strbuff(5) = "0"   ''トング状態
            Else
                strbuff(5) = "1"   ''トング状態
            End If

            Me.lbl_Data計測時刻.Text = strbuff(0)
            Me.lbl_Dataファイル名.Text = strbuff(1)

            Me.Lbl_DataX軸.Text = strbuff(2) ''RKデータ(X軸)
            Me.Lbl_DataY軸.Text = strbuff(3) ''RKデータ(Y軸)
            Me.Lbl_DataZ軸.Text = strbuff(4) ''RKデータ(Z軸)

            If strbuff(5) = "0" Then         ''DIデータ
                Me.lblDataトングSTS.Text = "開"
            Else
                Me.lblDataトングSTS.Text = "閉"
            End If
        Else
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.mstr計測履歴_7 = Me.mstr計測履歴_7 & strbuff2 & vbCrLf
                Case mEnm倉庫区分.第８倉庫
                    Me.mstr計測履歴_8 = Me.mstr計測履歴_8 & strbuff2 & vbCrLf
                Case mEnm倉庫区分.第９倉庫
                    Me.mstr計測履歴_9 = Me.mstr計測履歴_9 & strbuff2 & vbCrLf
            End Select
        End If


    End Sub

    Private Sub mSub不要ファイル削除(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim strDir計測 As String
        Dim strDir履歴 As String
        Dim files計測 As String()       ''計測データファイル用
        Dim files履連 As String()   ''履歴・連番データファイル用
        Dim i As Integer            ''ループ制御

        ''選択（デイレクトリ）
        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                strDir計測 = Me.mstrFileDir計測DATA_7
                strDir履歴 = Me.mstrFileDir計測履歴_7
            Case mEnm倉庫区分.第８倉庫
                strDir計測 = Me.mstrFileDir計測DATA_8
                strDir履歴 = Me.mstrFileDir計測履歴_8
            Case mEnm倉庫区分.第９倉庫
                strDir計測 = Me.mstrFileDir計測DATA_9
                strDir履歴 = Me.mstrFileDir計測履歴_9
        End Select

        ''指定ディレクトリの全ファイルを取得
        files計測 = MFile.gStrFileGet(strDir計測)
        files履連 = MFile.gStrFileGet(strDir履歴)

        '計測データファイル削除
        For i = 0 To files計測.Length - 1
            '作成日付が前日以前のファイルを検索
            If files計測(i).Substring(strDir計測.Length, 8) < mstrFile日付 Then
                '削除
                File.Delete(files計測(i))
            End If
        Next

        '履歴/連番データファイル削除
        For i = 0 To files履連.Length - 1
            '作成日付が前日以前のファイルを検索
            If files履連(i).Substring(strDir履歴.Length + 5, 8) < mstrFile日付 Then
                '削除
                File.Delete(files履連(i))
            End If
        Next

    End Sub


    ''イベント -------------------------------------------------------------------------

    Private Sub btn終了_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn終了.Click

        ''メッセージボックス表示
        Me.mstrdiarst = MessageBox.Show("システムを終了します。" & MConst.MSG_確認, "確認メッセージ", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If Me.mstrdiarst = Windows.Forms.DialogResult.Yes Then
            ''機器切断 --------------------------------------------
            Call Me.mSub機器切断(mEnm倉庫区分.第７倉庫)

            ''ファイル保存（連番、計測履歴）
            Call Me.mSub計測履歴ファイル保存(mEnm倉庫区分.第７倉庫)
            Call Me.mSubファイル連番保存(mEnm倉庫区分.第７倉庫)

            Me.Close()
        End If

    End Sub
    ''機器の切断を行う
    Private Sub mSub機器切断(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim str機器ID As String()   ''機器IDbuff
        Dim i As Integer            ''ループ制御

        ''機器ID選択
        str機器ID = mstr機器ID選択(enm倉庫区分)

        '（キー：機器ID）
        For i = 0 To str機器ID.Length - 1

            '"ST"は対象外
            If mcon機器ID_ST_S <= i And i <= mcon機器ID_ST_E Then
                ''NULL
            End If

            '"RK"はこちら
            If mcon機器ID_RK_S <= i And i <= mcon機器ID_RK_E Then
                Call Me.mSubClose_RK(str機器ID(i))
            End If

            '"DI"はこちら
            If mcon機器ID_DI = i Then
                Call Me.mSubClose_DI(str機器ID(i))
            End If
        Next

    End Sub

    ''機器チェックを行う
    Private Sub btn機器チェック_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn機器チェック.Click

        ''変数宣言
        Dim rtnbln As Boolean = True ''戻り値

        rtnbln = mbln接続チェック(mEnm倉庫区分.第７倉庫)

        ''Ping監視MODEはFalse
        Me.mblnPing監視MODE_7 = False

        ''信号監視
        If rtnbln Then
            ''信号監視OFFならON
            If Not Me.tmr7.Enabled Then
                Me.tmr7.Enabled = rtnbln
            End If
            Me.mbln初回取得_7 = True
            Me.mSub機器状況SET(False, MConst.MSG_CHK_OK)
            Me.mSub機器状況SET(True, "信号監視を開始しました。")   ''メッセージ表示
            ''システムSTS更新
            Me.SLblシステム状態.Text = "オンライン"
        Else
            ''信号監視ONならOFF
            If Me.tmr7.Enabled Then
                Me.tmr7.Enabled = rtnbln
            End If
            Me.mSub機器状況SET(True, "信号監視を停止しました。")   ''メッセージ表示
            ''システムSTS更新
            Me.SLblシステム状態.Text = "オフライン"
        End If

    End Sub


    ''タイマー -------------------------------------------------------------------------

    Private Sub mSub時刻設定init()

        Dim strTimeFormat As String
        Dim intTimeInterval As Integer

        ''時刻表示設定
        strTimeFormat = MFile.gStrParameterStr("TimeFormat", FORMAT_日時)
        intTimeInterval = CType(MFile.gStrParameterStr("TimeInterval", "1000"), Integer)

        Me.tmrNow.Interval = intTimeInterval

        If tmrNow.Interval > 0 Then
            Me.Slbl現在時刻.Text = Format(Now, FORMAT_日時)
            tmrNow.Enabled = True
        Else
            tmrNow.Enabled = False
        End If

    End Sub

    Private Sub tmrNow_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrNow.Tick
        tmrNow.Enabled = False
        Me.Slbl現在時刻.Text = Format(Now, FORMAT_日時)
        tmrNow.Enabled = True
    End Sub

    ''スレッド処理 ---------------------------------------------------------------------

    Private Sub mSubスレッド設定init()

        '第７倉庫
        Dim intTimeInterval As Integer
        intTimeInterval = CType(MFile.gStrParameterStr("TimeInterval_7", "1000"), Integer)

        Me.tmr7.Interval = intTimeInterval

        If Me.tmr7.Interval > 0 Then
            ''NULL
        Else
            Me.tmr7.Enabled = False
        End If

    End Sub

    ''第７倉庫信号監視
    Private Sub tmr7_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr7.Tick
        Dim blnEnable As Boolean = True  ''スレッド許可

        ''STOP
        Me.tmr7.Enabled = False

        ''スレッド処理判断
        If Me.mblnPing監視MODE_7 Then

            ''DIPing監視モード
            Dim rtnbln As Boolean = True

            If Not Me.mblnLANチェック(mstr機器ID_7(mcon機器ID_DI)) Then
                ''DIのPing失敗
                rtnbln = False
            End If

            If rtnbln Then

                '機器立上り中の可能性があるため待機
                System.Threading.Thread.Sleep(CType(MFile.gStrParameterStr("IniWaitInterval_7", "5000"), Integer))

                If Not Me.mbln機器別接続チェック(mEnm機器区分.DI, mstr機器ID_7(mcon機器ID_DI)) Then
                    ''DIの機器チェック失敗
                    rtnbln = False
                End If

                If rtnbln Then
                    ''正常 - 復帰OK
                    Me.mbln初回取得_7 = True
                Else
                    ''異常 - 復帰NG
                    blnEnable = False
                End If

                Me.mblnPing監視MODE_7 = False

            End If

        Else
            ''距離計測要求監視モード
            blnEnable = Me.mblnスレッド処理(mEnm倉庫区分.第７倉庫)

        End If

        ''START
        Me.tmr7.Enabled = blnEnable

        If Not blnEnable Then
            Me.SLblシステム状態.Text = "オフライン"
            Call Me.mSub機器状況SET(True, "信号監視を停止しました。")
        End If

    End Sub

    Private Function mblnスレッド処理(ByVal enm倉庫区分 As mEnm倉庫区分) As Boolean

        Dim str機器ID As String()          ''機器IDbuff
        Dim i As Integer                   ''ループ制御
        Dim rtnbln As Boolean = True       ''戻り値

        str機器ID = mstr機器ID選択(enm倉庫区分)


        ''DIデータ取得 ---------------------------------------------------------------

        '↓ 20130130 Morimoto
        'If Not mblnDATチェック_DI(mEnmDIDATA区分.POW, str機器ID(mcon機器ID_DI), False) Then
        '
        '    'DIのPing接続エラーはメッセージを出さない 
        '    '2007/10/22 inoue ★トング取り外し対応
        '    If Me.mblnPing監視MODE_7 Then
        '        rtnbln = True
        '        Return rtnbln
        '    Else
        '        Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
        '        Call Me.mSub表示初期_計測()  '表示クリア
        '        Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加
        '        rtnbln = False
        '        Return rtnbln
        '    End If
        '
        'End If
        '
        'If Not mblnDATチェック_DI(mEnmDIDATA区分.TNG, str機器ID(mcon機器ID_DI), False) Then
        '
        '    'DIのPing接続エラーはメッセージを出さない 
        '    '2007/10/22 inoue ★トング取り外し対応
        '    If Me.mblnPing監視MODE_7 Then
        '        rtnbln = True
        '        Return rtnbln
        '    Else
        '        Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
        '        Call Me.mSub表示初期_計測()  '表示クリア
        '        Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加
        '        rtnbln = False
        '        Return rtnbln
        '    End If
        'End If
        '

        '電源と開閉は一括で取得し処理するように変更
        If Not Me.mbln電源状態開閉状態一括取得(str機器ID(mcon機器ID_DI)) Then

            'DIのPing接続エラーはメッセージを出さない 
            If Me.mblnPing監視MODE_7 Then
                rtnbln = True
                Return rtnbln
            Else
                Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
                Call Me.mSub表示初期_計測()  '表示クリア
                Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加
                rtnbln = False
                Return rtnbln
            End If
        End If
        '↑ 20130130 Morimoto

        '↓ 20130130 Morimoto

        ''データ比較処理 ---------------------------------------------------------------
        If Not Me.mblnDIデータ比較(enm倉庫区分, str機器ID) Then
            Return rtnbln
        End If

        ''距離計測処理 ---------------------------------------------------------------
        'X,Y,Z分ループ
        For i = mcon機器ID_RK_S To mcon機器ID_RK_E
            If Not Me.mbln距離計測(enm倉庫区分, str機器ID(i)) Then

                Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
                Call Me.mSub表示初期_計測()  '表示クリア
                Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加

                rtnbln = False
                Return rtnbln
            End If
        Next

        ''ファイル作成処理 ---------------------------------------------------------------
        If Not Me.mbln計測ファイル作成(enm倉庫区分, str機器ID) Then

            Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
            Call Me.mSub表示初期_計測()  '表示クリア
            Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加

            rtnbln = False
            Return rtnbln
        End If


        ''''
        ''''-------------------------------- 処理メモ（20130130)
        ''''なぜこの様な事をしているか？
        ''''閉状態で電源を落とした場合、「開閉」も「開」状態になる（機械側の仕様）
        ''''機械側の仕様からすると、「電源」が落ちたら「開閉」も同じタイミングで「開」になるはずだが
        ''''取得タイミングで「電源」信号が「ON」で「開閉」だけが「開」に落ちる事象がある
        ''''その為、１スキャンずらして書き込みたいからこんな処理になっている
        ''''１スキャン後、電源状態が変わって無かったら、初回スキャンで取得したデータで
        ''''ファイルを作るようにした
        ''''-------------------------------------

        '''''データ比較処理 ---------------------------------------------------------------
        '''If Me.mblnDIデータ比較(enm倉庫区分, str機器ID) Then

        '''    '既に前スキャンで書込み待ちになっていたら無視（１スキャン目「閉」２スキャン目「開」となったら）
        '''    If Not Me.mBlnファイル書込要求 Then
        '''        ''距離計測処理 ---------------------------------------------------------------
        '''        'X,Y,Z分ループ
        '''        For i = mcon機器ID_RK_S To mcon機器ID_RK_E
        '''            'If Not Me.mbln距離計測(enm倉庫区分, str機器ID(i)) Then

        '''            '    Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
        '''            '    Call Me.mSub表示初期_計測()  '表示クリア
        '''            '    Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加

        '''            '    rtnbln = False
        '''            '    Return rtnbln
        '''            'End If
        '''        Next

        '''        '計測した時の状態を覚える
        '''        Me.mstr開閉状態 = CStr(Me.mhstDIデータ_CORR("INTNG_" & str機器ID(mcon機器ID_DI)))
        '''        Me.mBlnファイル書込要求 = True

        '''    End If

        '''    '計測スキャンでは書き込みたくないのでOKで抜ける
        '''    Return True

        '''End If

        '''' ファイル書込要求が無ければ距離取得
        '''If Me.mBlnファイル書込要求 Then
        '''    ''ファイル作成処理 ---------------------------------------------------------------
        '''    If Not Me.mbln計測ファイル作成(enm倉庫区分, str機器ID) Then

        '''        Call Me.mSub計測履歴SET()    '計測データを計測履歴へ追加
        '''        Call Me.mSub表示初期_計測()  '表示クリア
        '''        Call Me.mSub計測履歴SET(Format(Now, FORMAT_日時) & Space(4) & MConst.MSG_SLD_NG)  ''エラー時 txt計測履歴にMSG追加

        '''        rtnbln = False
        '''        Return rtnbln
        '''    End If
        '''    Me.mBlnファイル書込要求 = False
        '''End If           '

        '↑ 20130130 Morimoto

        Return rtnbln


    End Function

    Private Function mblnDIデータ比較(ByVal enm倉庫区分 As mEnm倉庫区分, ByVal str機器ID As String()) As Boolean

        Dim bln初回 As Boolean        ''初回監視判定
        Dim rtnbln As Boolean = True  ''戻り値
        Dim blnPOW As Boolean = False ''POW信号変化
        Dim blnTNG As Boolean = False ''TNG信号変化

        ''初回選択
        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                bln初回 = Me.mbln初回取得_7
            Case mEnm倉庫区分.第８倉庫
                bln初回 = Me.mbln初回取得_8
            Case mEnm倉庫区分.第９倉庫
                bln初回 = Me.mbln初回取得_9
        End Select

        ''機器ID選択
        str機器ID = mstr機器ID選択(enm倉庫区分)

        If bln初回 Then
            ''初回取得時は比較なし（CORR→PREVへのコピーのみ）
            Me.mhstDIデータ_PREV("INPOW_" & str機器ID(mcon機器ID_DI)) = Me.mhstDIデータ_CORR("INPOW_" & str機器ID(mcon機器ID_DI))
            Me.mhstDIデータ_PREV("INTNG_" & str機器ID(mcon機器ID_DI)) = Me.mhstDIデータ_CORR("INTNG_" & str機器ID(mcon機器ID_DI))

            bln初回 = False

            ''初回更新
            Select Case enm倉庫区分
                Case mEnm倉庫区分.第７倉庫
                    Me.mbln初回取得_7 = bln初回
                Case mEnm倉庫区分.第８倉庫
                    Me.mbln初回取得_8 = bln初回
                Case mEnm倉庫区分.第９倉庫
                    Me.mbln初回取得_9 = bln初回
            End Select

            rtnbln = False
            '↓----- 20130130  Morimoto
            Me.mBlnファイル書込要求 = False     '開閉状態有無クリア
            Me.mstr電源変化有無 = "0"   '電源変化「無」
            '↑----- 20130130 Morimoto
        Else
            ''比較開始

            '↓----- 20130130  Morimoto

            '''1.トングSTSのチェック（PREV ≠ CORR なら次チェックへ）
            ''If CStr(Me.mhstDIデータ_PREV("INTNG_" & str機器ID(mcon機器ID_DI))) <> _
            ''   CStr(Me.mhstDIデータ_CORR("INTNG_" & str機器ID(mcon機器ID_DI))) Then

            ''    blnPOW = True

            ''    '2.電源ON/OFFのチェック （PREV ≠ CORR なら計測なし）
            ''    If CStr(Me.mhstDIデータ_PREV("INPOW_" & str機器ID(mcon機器ID_DI))) <> _
            ''       CStr(Me.mhstDIデータ_CORR("INPOW_" & str機器ID(mcon機器ID_DI))) Then

            ''        blnTNG = True

            ''        rtnbln = False   '距離計測OFF
            ''    End If
            ''Else
            ''    rtnbln = False       '距離計測OFF
            ''End If
            '


            '1.電源ON/OFFのチェック （PREV ≠ CORR なら計測なし）
            If CStr(Me.mhstDIデータ_PREV("INPOW_" & str機器ID(mcon機器ID_DI))) <> _
               CStr(Me.mhstDIデータ_CORR("INPOW_" & str機器ID(mcon機器ID_DI))) Then

                rtnbln = False                      '距離計測OFF（電源「断or通」の時は開閉信号も変わるので無視する）
                Me.mBlnファイル書込要求 = False     '電源状態が変わったので要求クリア
                Me.mstr電源変化有無 = "1"           '電源変化「有」

                If CStr(Me.mhstDIデータ_PREV("INTNG_" & str機器ID(mcon機器ID_DI))) <> _
                   CStr(Me.mhstDIデータ_CORR("INTNG_" & str機器ID(mcon機器ID_DI))) Then

                    '電源が落ちて、開閉も変化していたら正常の電源断とみなし
                    '次スキャンの電源変化有無は無視する
                    Me.mstr電源変化有無 = "0"           '電源変化「有」

                End If


            Else

                '2.電源が入っていて
                If CStr(Me.mhstDIデータ_CORR("INPOW_" & str機器ID(mcon機器ID_DI))) = "1" Then

                    '3.開閉チェック（PREV ≠ CORR なら信号変化ありとみなす）
                    If CStr(Me.mhstDIデータ_PREV("INTNG_" & str機器ID(mcon機器ID_DI))) <> _
                       CStr(Me.mhstDIデータ_CORR("INTNG_" & str機器ID(mcon機器ID_DI))) Then


                        '4.前回の電源状態確認
                        If Me.mstr電源変化有無 = "0" Then

                            '前回電源ON/OFF無なら開閉があった！
                            rtnbln = True       '距離計測ON
                        Else

                            '前回電源ON/OFFがあったら遅れで変化があるかもしれないので無視
                            rtnbln = False      '距離計測OFF
                        End If

                    Else

                        '状態が変わっていないので無視（開or閉の状態の継続）
                        rtnbln = False   '距離計測OFF
                    End If
                Else
                    '電源が入ってなかったら無視（信号は入ってこないはずなので）
                    rtnbln = False   '距離計測OFF
                End If
                Me.mstr電源変化有無 = "0"   '電源変化「無」
            End If
            '↑----- 20130130 Morimoto


            '↓20130118Morimoto
            '' 開閉履歴書込み（20121218MorimotoADD)
            'mSub開閉履歴()
            If Me.mstrLOGMODE = "1" Then
                mSub開閉履歴()
            End If
            '↑20130118Morimoto

            ''CORR→PREVへのコピー
            Me.mhstDIデータ_PREV("INPOW_" & str機器ID(mcon機器ID_DI)) = Me.mhstDIデータ_CORR("INPOW_" & str機器ID(mcon機器ID_DI))
            Me.mhstDIデータ_PREV("INTNG_" & str機器ID(mcon機器ID_DI)) = Me.mhstDIデータ_CORR("INTNG_" & str機器ID(mcon機器ID_DI))

            End If

            ''testモードなら以下の処理
            If Me.mstrSYSMODE = "1" Then
                Call Me.mSubtestDI監視(blnPOW, blnTNG)
            End If

            Return rtnbln

    End Function

    Private Sub mSubtestDI監視(ByVal blnPOW As Boolean, ByVal blnTNG As Boolean)

        Me.Lbltest_P_POW.Text = CStr(Me.mhstDIデータ_PREV("INPOW_" & "D7"))
        Me.Lbltest_P_TNG.Text = CStr(Me.mhstDIデータ_PREV("INTNG_" & "D7"))

        Me.Lbltest_C_POW.Text = CStr(Me.mhstDIデータ_CORR("INPOW_" & "D7"))
        Me.Lbltest_C_TNG.Text = CStr(Me.mhstDIデータ_CORR("INTNG_" & "D7"))

        If blnPOW Then
            Me.Lbltest_POW.Text = "有"
        Else
            Me.Lbltest_POW.Text = "無"
        End If

        If blnTNG Then
            Me.Lbltest_TNG.Text = "有"
        Else
            Me.Lbltest_TNG.Text = "無"
        End If


    End Sub

    Private Function mbln距離計測(ByVal enm倉庫区分 As mEnm倉庫区分, ByVal str機器ID As String) As Boolean

        Dim rtnbln As Boolean = True '戻り値

        ''接続チェック
        If mblnLANチェック(str機器ID) Then
            'OKなら計測
            Me.mhstRKデータ(str機器ID) = Me.mstrデータ取得_RK(str機器ID)

            If CStr(Me.mhstRKデータ(str機器ID)) = "-1" Then
                rtnbln = False  'ファイル作成OFF
            End If
        Else
            rtnbln = False  'ファイル作成OFF
        End If

        Return rtnbln

    End Function

    Private Function mbln計測ファイル作成(ByVal enm倉庫区分 As mEnm倉庫区分, ByVal str機器ID As String()) As Boolean

        Dim str連番 As String = ""    ''連番buff
        Dim strDir As String = ""     ''ファイルディレクトリbuff
        Dim strPath As String = ""    ''ファイルパスbuff

        '【表示】計測データを計測履歴へ追加
        Call Me.mSub計測履歴SET()

        '選択（連番、ディレクトリ）
        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                str連番 = CStr(Me.mintFile連番_7).PadLeft(4, CChar("0"))
                strDir = Me.mstrFileDir計測DATA_7
            Case mEnm倉庫区分.第８倉庫
                str連番 = CStr(Me.mintFile連番_8).PadLeft(4, CChar("0"))
                strDir = Me.mstrFileDir計測DATA_8
            Case mEnm倉庫区分.第９倉庫
                str連番 = CStr(Me.mintFile連番_9).PadLeft(4, CChar("0"))
                strDir = Me.mstrFileDir計測DATA_9
        End Select

        'ファイル名（日付+連番(0001～9999).txt）
        strPath = strDir & Me.mstrFile日付 & str連番 & ".txt"

        'ファイル書込
        MFile.gBlnLogFileLineWrite(CStr(Me.mhstRKデータ(str機器ID(2))), strPath, False)      ''RKデータ(X軸)
        MFile.gBlnLogFileLineWrite(CStr(Me.mhstRKデータ(str機器ID(3))), strPath, True)       ''RKデータ(Y軸)
        MFile.gBlnLogFileLineWrite(CStr(Me.mhstRKデータ(str機器ID(4))), strPath, True)       ''RKデータ(Z軸)

        '↓----- 20130130 Morimoto
        MFile.gBlnLogFileLineWrite(CStr(Me.mhstDIデータ_CORR("INTNG_" & str機器ID(5))), strPath, True)  ''DIデータ
        '計測した時の開閉状態を書き込み
        'MFile.gBlnLogFileLineWrite(Me.mstr開閉状態, strPath, True)  ''DIデータ
        '↑----- 20130130 Morimoto

        '連番更新（インクリメント）
        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                Me.mintFile連番_7 += 1
            Case mEnm倉庫区分.第８倉庫
                Me.mintFile連番_8 += 1
            Case mEnm倉庫区分.第９倉庫
                Me.mintFile連番_9 += 1
        End Select


        '【表示】計測データ更新
        Call Me.mSub表示更新_計測(str機器ID, Me.mstrFile日付 & str連番 & ".txt")

        Return True

    End Function

    ''キー情報 -------------------------------------------------------------------------

    Private Function mstr機器ID選択(ByVal enm倉庫区分 As mEnm倉庫区分) As String()

        Dim rtnstr As String() = {"", "", "", "", "", "", ""}

        Select Case enm倉庫区分
            Case mEnm倉庫区分.第７倉庫
                rtnstr = Me.mstr機器ID_7
            Case mEnm倉庫区分.第８倉庫
                rtnstr = Me.mstr機器ID_8
            Case mEnm倉庫区分.第９倉庫
                rtnstr = Me.mstr機器ID_9
        End Select

        Return rtnstr

    End Function


    ''インスタンス----------------------------------------------------------------------

    Private Sub mSub機器制御用インスタンス生成(ByVal enm倉庫区分 As mEnm倉庫区分)

        Dim str機器ID As String()   ''機器IDbuff
        Dim i As Integer         ''ループ制御

        ''機器ID選択
        str機器ID = mstr機器ID選択(enm倉庫区分)

        '（キー：機器ID）
        For i = 0 To str機器ID.Length - 1

            '"ST"は対象外
            If mcon機器ID_ST_S <= i And i <= mcon機器ID_ST_E Then
                ''NULL
            End If

            '"RK"はこちら
            If mcon機器ID_RK_S <= i And i <= mcon機器ID_RK_E Then
                Call Me.mSubレーザー距離計インスタンス生成(str機器ID(i))
            End If

            '"DI"はこちら
            If mcon機器ID_DI = i Then
                Call Me.mSubデジタル入出力インスタンス生成(str機器ID(i))
            End If

        Next

    End Sub
    'インスタンス生成
    Private Sub mSubレーザー距離計インスタンス生成(ByVal str機器ID As String)

        Dim obj As New CDMECtl

        ''パラメータ格納用
        Dim IntPortNumber As Short      ''ポート番号
        Dim IntBaudRate As Integer      ''ボーレート
        Dim IntParity As Short          ''パリティ
        Dim IntDataBits As Integer      ''データビット
        Dim IntStopBits As Integer      ''ストップビット

        ''パラメータ取得（Configファイルより）
        IntPortNumber = CShort(MFile.gStrParameterStr("PORTNUMBER_" & str機器ID, "4"))
        IntBaudRate = CInt(MFile.gStrParameterStr("BAUDRATE_" & str機器ID, "19200"))
        IntParity = CShort(MFile.gStrParameterStr("PARITY_" & str機器ID, "2"))
        IntDataBits = CInt(MFile.gStrParameterStr("DATABITS_" & str機器ID, "7"))
        IntStopBits = CInt(MFile.gStrParameterStr("STOPBITS_" & str機器ID, "1"))

        ''インスタンス生成

        'mColCls距離計にインスタンスを登録していく
        Me.mColCls距離計.Add(New CDMECtl(IntPortNumber, IntBaudRate, IntParity, IntDataBits, IntStopBits), str機器ID)

        'オフセットの設定
        CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).mIntOffSet = CInt(MFile.gStrParameterStr("OFFSET_" & str機器ID, "0"))

    End Sub
    'インスタンス生成
    Private Sub mSubデジタル入出力インスタンス生成(ByVal str機器ID As String)

        ''パラメータ格納用
        Dim IntDID As Short     ''デバイスID
        Dim strDN As String     ''デバイス名　　

        ''パラメータ取得（Configファイルより）
        IntDID = CShort(MFile.gStrParameterStr("DID_" & str機器ID, "00"))
        strDN = MFile.gStrParameterStr("DNAME_" & str機器ID, "DIO080000")

        ''インスタンス生成

        'mColClsD入力にインスタンスを登録していく
        Me.mColClsD入力.Add(New CDio(IntDID, strDN), str機器ID)

    End Sub

    ''機器機能 ------------------------------------------------------------------------

    Private Function mstrデータ取得_RK(ByVal str機器ID As String) As String

        Dim rtnstr As String = "999999"
        Dim i As Integer = 0  ''2008/4/30 Inoue Add (Ver.1.0.0.2)

        ''測定要求コマンド発行
        'CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).Command_DISTANCE()
        CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).PortOpen()

        ''距離データ受信

        ''受信処理のリトライ追加 2008/4/30 Inoue Add ↓ (Ver.1.0.0.2)
        For i = 1 To Me.mReCnt_ReadLenData

            CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).ReceiveEventListener()

            ''距離データ取得
            rtnstr = CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).ReadData

            ''ブランクでなければ抜ける
            If Not rtnstr.Trim.Length.Equals(0) Then
                Exit For
            Else
                ''リトライ（但し、規定リトライ回数に達した場合は、置換データを使用）
                If i.Equals(Me.mReCnt_ReadLenData) Then
                    rtnstr = Me.mStrReplaceLendata
                Else
                    ''NULL
                End If

                ''待機(default:100)
                System.Threading.Thread.Sleep(Me.mReIntvl_ReadLenData)

            End If
        Next

        ''受信処理のリトライ追加 2008/4/30 Inoue Add ↑ (Ver.1.0.0.2)

        ''クローズ
        CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).PortClose()


        Return rtnstr

    End Function
    'デジタル入力データ取得
    Private Function mblnデータ取得_DI(ByVal str機器ID As String, ByVal Id As Short, ByVal BitNo As Short, ByRef Data As Byte) As Boolean

        Dim rtnbln As Boolean = True

        If Not CType(Me.mColClsD入力.Item(str機器ID), CDio).gBlnビット入力(Id, BitNo, Data) Then
            rtnbln = False
            Data = 9          ''エラーNo
        End If

        Return rtnbln
    End Function

    'デジタル入力１バイトデータ取得
    Private Function mblnバイトデータ取得_DI(ByVal str機器ID As String, ByVal Id As Short, ByVal StartBitNo As Short, ByRef Data As Byte) As Boolean

        Dim rtnbln As Boolean = True

        If Not CType(Me.mColClsD入力.Item(str機器ID), CDio).gBlnバイト入力(Id, StartBitNo, Data) Then
            rtnbln = False
            Data = 9          ''エラーNo
        End If

        Return rtnbln
    End Function
    'クローズ
    Private Sub mSubClose_RK(ByVal str機器ID As String)

        CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).PortClose()

    End Sub
    'クローズ
    Private Sub mSubClose_DI(ByVal str機器ID As String)

        CType(Me.mColClsD入力.Item(str機器ID), CDio).gBlnDIOクローズ()

    End Sub


    ''接続チェック----------------------------------------------------------------------

    Private Function mbln接続チェック(ByVal enm倉庫区分 As mEnm倉庫区分) As Boolean

        ''変数宣言
        Dim rtnbln As Boolean = True      ''戻り値
        Dim str機器ID As String()         ''機器IDbuff
        Dim i As Integer                  ''ループ制御
        Dim blnstXY As Boolean = True     ''ステーションXY
        Dim blnstZD As Boolean = True     ''ステーションZD

        ''画面表示系設定 -----------------------------------------------------------------

        ''表示初期設定
        Call Me.mSub表示初期_機器()
        ''txt機器状況クリア
        Me.txt機器状況.Clear()

        ''チェック開始 -------------------------------------------------------------------

        ''機器ID選択
        str機器ID = mstr機器ID選択(enm倉庫区分)

        For i = 0 To str機器ID.Length - 1

            '"ST"
            If mcon機器ID_ST_S <= i And i <= mcon機器ID_ST_E Then
                ''ステーションのLANチェックは行わない 2007/9/29 inoue
                'NULL
            End If

            '"RK"
            If mcon機器ID_RK_S <= i And i <= mcon機器ID_RK_E Then
                ''X,Y or Z,Dのチェック
                If Not Me.mbln機器別接続チェック(mEnm機器区分.RK, str機器ID(i)) Then
                    rtnbln = False
                End If
            End If

            '"DI"
            If mcon機器ID_DI = i Then
                'ステーションでこけていればチェックはスルー
                'If blnstZD Then
                If Not Me.mbln機器別接続チェック(mEnm機器区分.DI, str機器ID(i)) Then
                    rtnbln = False
                    'End If
                End If
            End If

        Next

        Return rtnbln

    End Function

    Private Function mbln機器別接続チェック(ByVal enm機器区分 As mEnm機器区分, ByVal str機器ID As String) As Boolean


        Dim rtnbln As Boolean = True ''戻り値

        ''共通チェック ----------------------------------------------------

        ''LAN接続チェック
        If Not Me.mblnLANチェック(str機器ID) Then
            Call Me.mSub機器状況SET(str機器ID, MConst.MSG_LAN_ERR)
            rtnbln = False
        End If

        Call Me.mSub表示更新_機器(str機器ID, rtnbln, mEnmCHK区分.LAN)

        ''機器別チェック --------------------------------------------------

        '共通チェックがOKの場合のみ処理
        If rtnbln Then
            Select Case enm機器区分
                Case mEnm機器区分.RK

                    If Not Me.mblnCOMチェック_RK(str機器ID) Then           ''COM接続チェック
                        Call Me.mSub機器状況SET(str機器ID, MConst.MSG_COM_ERR)
                        rtnbln = False
                    End If

                    Call Me.mSub表示更新_機器(str機器ID, rtnbln, mEnmCHK区分.COM)

                    If rtnbln Then
                        If Not Me.mblnDATチェック_RK(str機器ID) Then       ''距離データ取得チェック
                            Call Me.mSub機器状況SET(str機器ID, MConst.MSG_DAT_ERR)
                            rtnbln = False
                        End If
                        Call Me.mSub表示更新_機器(str機器ID, rtnbln, mEnmCHK区分.DAT)
                    End If

                    ''チェック後、COMポートは一旦閉じる。
                    Call Me.mSubClose_RK(str機器ID)

                Case mEnm機器区分.DI

                    If Not Me.mblnCOMチェック_DI(str機器ID) Then            ''COM接続チェック
                        Call Me.mSub機器状況SET(str機器ID, MConst.MSG_COM_ERR)
                        rtnbln = False
                    End If
                    Call Me.mSub表示更新_機器(str機器ID, rtnbln, mEnmCHK区分.COM)

                    If rtnbln Then
                        '電源
                        If Not Me.mblnDATチェック_DI(mEnmDIDATA区分.POW, str機器ID, True) Then        ''DIOデータ取得チェック
                            rtnbln = False
                        End If
                        Call Me.mSub表示更新_機器(str機器ID, rtnbln, mEnmCHK区分.DAT, mEnmDIDATA区分.POW)
                        'トング
                        If Not Me.mblnDATチェック_DI(mEnmDIDATA区分.TNG, str機器ID, True) Then       ''DIOデータ取得チェック
                            rtnbln = False
                        End If
                        Call Me.mSub表示更新_機器(str機器ID, rtnbln, mEnmCHK区分.DAT, mEnmDIDATA区分.TNG)

                        '画面更新
                        If Not rtnbln Then
                            Call Me.mSub機器状況SET(str機器ID, MConst.MSG_DAT_ERR)
                        End If

                    End If

                    ''問題ありの場合、機器を一旦閉じる。
                    If Not rtnbln Then
                        Call Me.mSubClose_DI(str機器ID)
                    End If

                Case mEnm機器区分.ST
                    ''NULL
            End Select
        End If

        Return rtnbln

    End Function

    ''共通

    Private Function mblnLANチェック(ByVal str機器ID As String) As Boolean

        Dim rtnbln As Boolean = True  ''戻り値
        Dim i As Integer              ''ループ制御

        ''PingCommand発行
        For i = 0 To mconLANリトライ回数

            If Not Me.mblnPingRequest(CStr(Me.mhst機器IP(str機器ID))) Then
                rtnbln = False
            Else
                rtnbln = True
                Exit For
            End If
        Next
      

        Return rtnbln

    End Function
    'Ping発行
    Private Function mblnPingRequest(ByVal strIPaddress As String) As Boolean

        Dim rtnbln As Boolean = True  ''戻り値

        'Pingオブジェクトの作成
        Dim p As New System.Net.NetworkInformation.Ping()
        Dim reply As System.Net.NetworkInformation.PingReply

        'Pingを送信する
        reply = p.Send(strIPaddress, 500)

        '結果を取得
        If reply.Status = System.Net.NetworkInformation.IPStatus.Success Then
            'Console.WriteLine("Reply from {0}:bytes={1} time={2}ms TTL={3}", _
            '    reply.Address, reply.Buffer.Length, _
            '    reply.RoundtripTime, reply.Options.Ttl)
        Else
            'Console.WriteLine("Ping送信に失敗。({0})", reply.Status)
            rtnbln = False
        End If

        p.Dispose()

        Return rtnbln

    End Function

    ''レーザー距離関連

    Private Function mblnCOMチェック_RK(ByVal str機器ID As String) As Boolean

        Dim rtnbln As Boolean = True  ''戻り値

        If Not CType(Me.mColCls距離計.Item(str機器ID), CDMECtl).PortOpen() Then
            rtnbln = False
        End If

        Return rtnbln

    End Function
    'データチェック
    Private Function mblnDATチェック_RK(ByVal str機器ID As String) As Boolean

        Dim rtnbln As Boolean = True  ''戻り値
        Dim str距離データ As String = ""

        ''距離データ取得
        Me.mhstRKデータ(str機器ID) = Me.mstrデータ取得_RK(str機器ID)

        ''チェック
        If CStr(Me.mhstRKデータ(str機器ID)) = "NODATA" Then
            rtnbln = False
        End If

        Return rtnbln

    End Function

    ''デジタル入出力関連

    Private Function mblnCOMチェック_DI(ByVal str機器ID As String) As Boolean

        Dim rtnbln As Boolean = True  ''戻り値

        ''DIO接続チェック
        If Not CType(Me.mColClsD入力.Item(str機器ID), CDio).gBlnDIOオープン Then
            rtnbln = False
        End If

        Return rtnbln

    End Function
    'DIOデータ取得チェック
    Private Function mblnDATチェック_DI(ByVal enmDIDATA区分 As mEnmDIDATA区分, ByVal str機器ID As String, ByVal blnCHK As Boolean) As Boolean

        Dim rtnbln As Boolean = True    ''戻り値
        Dim DID As Short                ''デバイスID
        Dim DATA As Byte                ''デバイスデータ
        Dim PORT As Short               ''デバイスポート

        If Not mblnLANチェック(str機器ID) Then
            Me.mblnPing監視MODE_7 = True
            Return False
        End If

        'デバイスID
        DID = CType(Me.mColClsD入力.Item(str機器ID), CDio).pデバイスID

        'デバイスポート
        Select Case enmDIDATA区分
            Case mEnmDIDATA区分.POW
                PORT = CShort(Me.mhstDIPort.Item("INPOW_" & str機器ID))
            Case mEnmDIDATA区分.TNG
                PORT = CShort(Me.mhstDIPort.Item("INTNG_" & str機器ID))
        End Select

        ''デバイスデータ
        If Not Me.mblnデータ取得_DI(str機器ID, DID, PORT, DATA) Then
            rtnbln = False
        End If

        ''データセット
        Select Case enmDIDATA区分
            Case mEnmDIDATA区分.POW
                If blnCHK Then   ''機器チェック
                    Me.mhstDIデータ_CHK("INPOW_" & str機器ID) = CStr(DATA)
                Else
                    Me.mhstDIデータ_CORR("INPOW_" & str機器ID) = CStr(DATA)
                End If

            Case mEnmDIDATA区分.TNG
                If blnCHK Then   ''機器チェック
                    Me.mhstDIデータ_CHK("INTNG_" & str機器ID) = CStr(DATA)
                Else
                    Me.mhstDIデータ_CORR("INTNG_" & str機器ID) = CStr(DATA)
                End If

        End Select

        Return rtnbln

    End Function

    '電源状態開閉状態一括取得(20130130 Morimoto)
    Private Function mbln電源状態開閉状態一括取得(ByVal str機器ID As String) As Boolean

        Dim rtnbln As Boolean = True    ''戻り値
        Dim DID As Short                ''デバイスID
        Dim DATA As Byte                ''デバイスデータ
        Dim PORT As Short               ''デバイスポート

        If Not mblnLANチェック(str機器ID) Then
            Me.mblnPing監視MODE_7 = True
            Return False
        End If

        'デバイスID
        DID = CType(Me.mColClsD入力.Item(str機器ID), CDio).pデバイスID

        ''デバイスデータ(X0～1byte)
        PORT = CShort(Me.mhstDIPort.Item("INPOW_" & str機器ID))
        If Not Me.mblnバイトデータ取得_DI(str機器ID, DID, PORT, DATA) Then
            rtnbln = False
        End If

        If rtnbln Then
            'X0(電源状態)
            If (DATA And &H1) = &H1 Then
                Me.mhstDIデータ_CORR("INPOW_" & str機器ID) = CStr(1)
            Else
                Me.mhstDIデータ_CORR("INPOW_" & str機器ID) = CStr(0)
            End If

            'X1(開閉状態)
            If (DATA And &H2) = &H2 Then
                Me.mhstDIデータ_CORR("INTNG_" & str機器ID) = CStr(1)
            Else
                Me.mhstDIデータ_CORR("INTNG_" & str機器ID) = CStr(0)
            End If
        Else
            Me.mhstDIデータ_CORR("INPOW_" & str機器ID) = CStr(9)
            Me.mhstDIデータ_CORR("INTNG_" & str機器ID) = CStr(9)
        End If

        Return rtnbln

    End Function


    ''画面表示系------------------------------------------------------------------------

    Private Sub mSub表示初期_機器()

        Dim i As Integer

        '機器CHKID登録件数分を処理
        '1.初期はすべてNGパターンの表示とする
        '2.機器チェックにて結果OKとなったものは都度OKパターンの表示に切り替える

        For i = 0 To Me.mstr機器CHKID.Length - 1
            'text = "OK" Backcolor = Drawing.Color.Cyan
            CType(Me.mColCtl機器CHK表示.Item(Me.mstr機器CHKID(i)), Label).Text = "-"
            CType(Me.mColCtl機器CHK表示.Item(Me.mstr機器CHKID(i)), Label).BackColor = Drawing.Color.Cyan

            If mcon機器CHKID_DATA_S <= i And i <= mcon機器CHKID_DATA_E Then
                CType(Me.mColCtl機器CHK表示.Item(Me.mstr機器CHKID(i)), Label).Text = "-"
                CType(Me.mColCtl機器CHK表示.Item(Me.mstr機器CHKID(i)), Label).BackColor = Drawing.Color.Cyan
                CType(Me.mColCtl機器CHK表示.Item(Me.mstr機器CHKID(i)), Label).TextAlign = Drawing.ContentAlignment.MiddleCenter
            End If
        Next

    End Sub
    '画面表示の更新を行う
    Private Sub mSub表示更新_機器(ByVal str機器ID As String, _
                                  ByVal blnrst As Boolean, _
                                  ByVal enmCHK区分 As mEnmCHK区分, _
                                  Optional ByVal enmDIDATA区分 As mEnmDIDATA区分 = mEnmDIDATA区分.POW)

        Select Case str機器ID
            Case "STXY7", "STXY8", "STXY9"
                'ステーションXY
                Select Case enmCHK区分
                    Case mEnmCHK区分.LAN
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).BackColor = Drawing.Color.Red

                        End If
                    Case mEnmCHK区分.COM
                        ''NULL
                    Case mEnmCHK区分.DAT
                        ''NULL
                End Select

            Case "STZD7", "STZD8", "STZD9"
                'ステーションZD
                Select Case enmCHK区分
                    Case mEnmCHK区分.LAN
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).BackColor = Drawing.Color.Red

                        End If

                    Case mEnmCHK区分.COM
                        ''NULL
                    Case mEnmCHK区分.DAT
                        ''NULL
                End Select

            Case "X7", "X8", "X9"
                '距離計X
                Select Case enmCHK区分
                    Case mEnmCHK区分.LAN
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_X"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_X"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_X"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_X"), Label).BackColor = Drawing.Color.Red
                        End If

                    Case mEnmCHK区分.COM
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("COM_X"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("COM_X"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("COM_X"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("COM_X"), Label).BackColor = Drawing.Color.Red
                        End If

                    Case mEnmCHK区分.DAT
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("RK_X"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("RK_X"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("DATA_X"), Label).Text = CStr(Me.mhstRKデータ(str機器ID))
                            CType(Me.mColCtl機器CHK表示.Item("DATA_X"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("DATA_X"), Label).TextAlign = Drawing.ContentAlignment.MiddleRight
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("RK_X"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("RK_X"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("DATA_X"), Label).Text = CStr(Me.mhstRKデータ(str機器ID))
                            CType(Me.mColCtl機器CHK表示.Item("DATA_X"), Label).BackColor = Drawing.Color.Red

                        End If

                End Select

            Case "Y7", "Y8", "Y9"
                '距離計Y
                Select Case enmCHK区分
                    Case mEnmCHK区分.LAN
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_Y"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_Y"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1X"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST1Y"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_Y"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_Y"), Label).BackColor = Drawing.Color.Red

                        End If

                    Case mEnmCHK区分.COM
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("COM_Y"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("COM_Y"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("COM_Y"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("COM_Y"), Label).BackColor = Drawing.Color.Red

                        End If

                    Case mEnmCHK区分.DAT
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("RK_Y"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("RK_Y"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Y"), Label).Text = CStr(Me.mhstRKデータ(str機器ID))
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Y"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Y"), Label).TextAlign = Drawing.ContentAlignment.MiddleRight
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("RK_Y"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("RK_Y"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Y"), Label).Text = CStr(Me.mhstRKデータ(str機器ID))
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Y"), Label).BackColor = Drawing.Color.Red

                        End If

                End Select

            Case "Z7", "Z8", "Z9"
                '距離計Z
                Select Case enmCHK区分
                    Case mEnmCHK区分.LAN

                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_Z"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_Z"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_Z"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_Z"), Label).BackColor = Drawing.Color.Red
                        End If

                    Case mEnmCHK区分.COM
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("COM_Z"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("COM_Z"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("COM_Z"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("COM_Z"), Label).BackColor = Drawing.Color.Red
                        End If

                    Case mEnmCHK区分.DAT
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("RK_Z"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("RK_Z"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Z"), Label).Text = CStr(Me.mhstRKデータ(str機器ID))
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Z"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Z"), Label).TextAlign = Drawing.ContentAlignment.MiddleRight
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("RK_Z"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("RK_Z"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Z"), Label).Text = CStr(Me.mhstRKデータ(str機器ID))
                            CType(Me.mColCtl機器CHK表示.Item("DATA_Z"), Label).BackColor = Drawing.Color.Red

                        End If

                End Select

            Case "D7", "D8", "D9"
                'デジタル入力
                Select Case enmCHK区分
                    Case mEnmCHK区分.LAN
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).BackColor = Drawing.Color.Cyan
                            CType(Me.mColCtl機器CHK表示.Item("接続_D"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("接続_D"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2Z"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_ST2D"), Label).BackColor = Drawing.Color.Red
                            CType(Me.mColCtl機器CHK表示.Item("接続_D"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("接続_D"), Label).BackColor = Drawing.Color.Red

                        End If

                    Case mEnmCHK区分.COM
                        If blnrst Then
                            CType(Me.mColCtl機器CHK表示.Item("COM_D"), Label).Text = "OK"
                            CType(Me.mColCtl機器CHK表示.Item("COM_D"), Label).BackColor = Drawing.Color.Cyan
                        Else
                            CType(Me.mColCtl機器CHK表示.Item("COM_D"), Label).Text = "NG"
                            CType(Me.mColCtl機器CHK表示.Item("COM_D"), Label).BackColor = Drawing.Color.Red
                        End If

                    Case mEnmCHK区分.DAT
                        If blnrst Then
                            Select Case enmDIDATA区分
                                Case mEnmDIDATA区分.POW
                                    CType(Me.mColCtl機器CHK表示.Item("DI_POW"), Label).Text = "OK"
                                    CType(Me.mColCtl機器CHK表示.Item("DI_POW"), Label).BackColor = Drawing.Color.Cyan
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_POW"), Label).Text = CStr(Me.mhstDIデータ_CORR.Item("INPOW_" & str機器ID))
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_POW"), Label).BackColor = Drawing.Color.Cyan
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_POW"), Label).TextAlign = Drawing.ContentAlignment.MiddleRight

                                Case mEnmDIDATA区分.TNG
                                    CType(Me.mColCtl機器CHK表示.Item("DI_TNG"), Label).Text = "OK"
                                    CType(Me.mColCtl機器CHK表示.Item("DI_TNG"), Label).BackColor = Drawing.Color.Cyan
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_TNG"), Label).Text = CStr(Me.mhstDIデータ_CORR.Item("INTNG_" & str機器ID))
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_TNG"), Label).BackColor = Drawing.Color.Cyan
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_TNG"), Label).TextAlign = Drawing.ContentAlignment.MiddleRight

                            End Select
                        Else
                            Select Case enmDIDATA区分
                                Case mEnmDIDATA区分.POW
                                    CType(Me.mColCtl機器CHK表示.Item("DI_POW"), Label).Text = "NG"
                                    CType(Me.mColCtl機器CHK表示.Item("DI_POW"), Label).BackColor = Drawing.Color.Red
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_POW"), Label).BackColor = Drawing.Color.Red

                                Case mEnmDIDATA区分.TNG
                                    CType(Me.mColCtl機器CHK表示.Item("DI_TNG"), Label).Text = "NG"
                                    CType(Me.mColCtl機器CHK表示.Item("DI_TNG"), Label).BackColor = Drawing.Color.Red
                                    CType(Me.mColCtl機器CHK表示.Item("DATA_TNG"), Label).BackColor = Drawing.Color.Red

                            End Select
                        End If
                End Select

            Case Else
                ''NULL
        End Select

    End Sub

    Private Sub mSub表示初期_計測()
        Me.lbl_Data計測時刻.Text = ""
        Me.lbl_Dataファイル名.Text = ""

        Me.Lbl_DataX軸.Text = ""
        Me.Lbl_DataY軸.Text = ""
        Me.Lbl_DataZ軸.Text = ""

        Me.lblDataトングSTS.Text = ""
        
    End Sub

    Private Sub mSub表示更新_計測(ByVal str機器ID As String(), ByVal strFname As String)
        '画面更新

        Me.lbl_Data計測時刻.Text = Format(Now, FORMAT_日時)
        Me.lbl_Dataファイル名.Text = strFname

        Me.Lbl_DataX軸.Text = CStr(Me.mhstRKデータ(str機器ID(2))).PadLeft(6, CChar(Space(1))) ''RKデータ(X軸)
        Me.Lbl_DataY軸.Text = CStr(Me.mhstRKデータ(str機器ID(3))).PadLeft(6, CChar(Space(1))) ''RKデータ(Y軸)
        Me.Lbl_DataZ軸.Text = CStr(Me.mhstRKデータ(str機器ID(4))).PadLeft(6, CChar(Space(1))) ''RKデータ(Z軸)


        '↓20130130Morimoto
        If CStr(Me.mhstDIデータ_CORR("INTNG_" & str機器ID(5))) = "0" Then         ''DIデータ
            Me.lblDataトングSTS.Text = "開"
        Else
            Me.lblDataトングSTS.Text = "閉"
        End If

        '''If Me.mstr開閉状態 = "0" Then         ''DIデータ
        '''    Me.lblDataトングSTS.Text = "開"
        '''Else
        '''    Me.lblDataトングSTS.Text = "閉"
        '''End If

        '↑20130130Morimoto

    End Sub

    'txt機器状況へのテキストセット
    Private Overloads Sub mSub機器状況SET(ByVal str機器ID As String, ByVal strConstMSG As String)

        Dim strbuff As String

        strbuff = CStr(Me.mhstMSG機器名(str機器ID)) & strConstMSG & vbCrLf
        Me.txt機器状況.AppendText(strbuff)

    End Sub

    Private Overloads Sub mSub機器状況SET(ByVal blnAdd As Boolean, ByVal strbuff As String)

        If blnAdd Then
            ''追記
            Me.txt機器状況.AppendText(strbuff & vbCrLf)
        Else
            ''上書き
            Me.txt機器状況.Clear()
            Me.txt機器状況.AppendText(strbuff & vbCrLf)
        End If

    End Sub

    'txt計測履歴へのテキストセット
    Private Overloads Sub mSub計測履歴SET()

        Dim strbuff As String = ""
        Dim strtxtbuff As String = ""

        If Not Me.lbl_Data計測時刻.Text = "" Then

            strtxtbuff = Me.txt計測履歴.Text

            strbuff = Me.lbl_Data計測時刻.Text & Space(4) & _
                      Me.lbl_Dataファイル名.Text & Space(4) & _
                      "X軸：" & Me.Lbl_DataX軸.Text & Space(2) & _
                      "Y軸：" & Me.Lbl_DataY軸.Text & Space(2) & _
                      "Z軸：" & Me.Lbl_DataZ軸.Text & Space(2) & _
                      "トング状態：" & Me.lblDataトングSTS.Text

            '計測履歴
            Me.txt計測履歴.Text = strbuff & vbCrLf & strtxtbuff
            'スクロールバー制御
            Call Me.mSubScrollToCaret(Me.txt計測履歴, True)

        End If

    End Sub

    Private Overloads Sub mSub計測履歴SET(ByVal strERR As String)

        Dim strtxtbuff As String = ""

        strtxtbuff = Me.txt計測履歴.Text

        '計測履歴
        Me.txt計測履歴.Text = strERR & vbCrLf & strtxtbuff
        'スクロールバー制御
        Call Me.mSubScrollToCaret(Me.txt計測履歴, True)

    End Sub

    ''スクロールバーを移動させる
    Private Sub mSubScrollToCaret(ByRef txtctl As TextBox, ByVal top As Boolean)

        If top Then
            ''最前行
            txtctl.SelectionStart = 1
        Else
            ''最終行
            txtctl.SelectionStart = txtctl.Text.Length
        End If

        txtctl.Focus()
        txtctl.ScrollToCaret()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Call Me.mSub計測履歴SET()

    End Sub

    Private Sub mSub処理履歴書込み(ByVal strMsg As String)

        Dim strFN As String                  ''ファイル名

        ''未登録時は作成しない
        If strMsg <> "" Then

            ''ファイル名
            strFN = Me.mstrFileDir計測履歴_7 & "IOCheck_" & Format(Now, "yyyyMMdd") & ".txt"
            ''追加書込み
            MFile.gBlnLogFileLineWrite(strMsg, strFN, True)

        End If

    End Sub


    Private Sub mSub開閉履歴()
        Dim strMsg As String
        Dim dtNow As DateTime = DateTime.Now

        strMsg = ""
        strMsg = strMsg & dtNow.ToString() & "." & Format(dtNow.Millisecond, "000")
        strMsg = strMsg & " PW R=" & CStr(Me.mhstDIデータ_PREV("INPOW_" & "D7")) & " C=" & CStr(Me.mhstDIデータ_CORR("INPOW_" & "D7"))
        strMsg = strMsg & " TG R=" & CStr(Me.mhstDIデータ_PREV("INTNG_" & "D7")) & " C=" & CStr(Me.mhstDIデータ_CORR("INTNG_" & "D7"))

        mSub処理履歴書込み(strMsg)

    End Sub


End Class