'*******************************************************************************
' @(h)  UsrFlx.vb
'                                           Ver.1.0 (            T.TADA )
'       **  Version 2.6.20071.324 を使用 **
'       C1.Common   ,c1.win.c1flexgrid  の参照追加が必要です
'
'
' @(s)  UsrFlx                             C1.Win.C1FlexGrid.C1FlexGridを継承
'       初期設定される作成プロパティー
'       pCondition = EnmCondition.Nomal
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       Styles.Frozen.BackColor = Color.Beige
'       Styles.Alternate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
'       Styles.Fixed.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Imports C1.Win.C1FlexGrid
Public Class UsrFlx
    Inherits C1.Win.C1FlexGrid.C1FlexGrid

    Public Const gCStrTotalName As String = "TOTAL"
    Public Const gCIntTotalRow As Integer = 2

    Private Const mIntAutoColSpace As Integer = 5   '自動列幅設定使用時の余白幅
    Private mAutoColSizeF As Integer
    Private mAutoColSizeT As Integer
    Private mAutoColSize As Boolean
    Private mTotal As Boolean
    Private mTotalColllection As New Collection()
    Private mBlnClear As Boolean 
    Private mDclicBtn As UsrBtn
    Private mEnmDisplyType As EnmDisplyType = EnmDisplyType.固定行表示

    Public Enum EnmDisplyType
        通常         '表示行分だけ行が増えていく
        固定行表示   '常に表示の行数をだす(エクセルタイプ)
    End Enum

    Public Enum EnmRowCount
        Enm表示行数
        Enm固定行数
    End Enum

#Region " コンポーネント デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Styles.Frozen.BackColor = Color.Beige
        Me.Styles.Alternate.BackColor = System.Drawing.Color.White
        Me.Styles.Fixed.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.pIsClear = True

        Me.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.AllowEditing = False
        Me.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.FocusRect = FocusRectEnum.Solid
        Me.HighLight = HighLightEnum.Always
    End Sub

    'Control は、コンポーネント一覧に後処理を実行するために、dispose を実行します。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。コード エディタを
    ' 使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "pDisply(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pDisply
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：表示行の有無
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pDisply() As Boolean
        Get
            If Me.Rows.Count = Me.pRowCount(EnmRowCount.Enm固定行数) Then
                pDisply = False
            Else
                pDisply = True
            End If
        End Get
    End Property

#Region "pTotal(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pTotal
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：合計行の有無
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pTotal() As Boolean
        Get
            pTotal = Me.mTotal
        End Get
    End Property

#Region "pRowCount(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pRowCount
    ' 引　数　：EnmRowCount
    ' 戻り値　：固定行数または表示行数
    ' 機能説明：固定行数または表示行数の取得
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pRowCount(Optional ByVal EnmRowCount As EnmRowCount = EnmRowCount.Enm固定行数) As Integer
        Get
            Select Case EnmRowCount
                Case EnmRowCount.Enm固定行数
                    pRowCount = Me.Rows.Fixed + Me.Rows.Frozen
                Case EnmRowCount.Enm表示行数
                    pRowCount = Me.Rows.Count - (Me.Rows.Fixed + Me.Rows.Frozen)
            End Select
        End Get
    End Property

#Region "pIsClearプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pIsClearプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期化するときににTextプロパティーを初期化するかどうか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pIsClear() As Boolean
        Get
            pIsClear = Me.mBlnClear
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnClear = Value
        End Set
    End Property

#Region "pDisplyType"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pDisplyType
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：表示の形式
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pDisplyType() As EnmDisplyType
        Get
            pDisplyType = Me.mEnmDisplyType
        End Get
        Set(ByVal Value As EnmDisplyType)
            Me.mEnmDisplyType = Value
        End Set
    End Property

#Region "pAutoColSize"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoColSize
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：自動で列幅設定をするか。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoColSize() As Boolean
        Get
            pAutoColSize = mAutoColSize
        End Get
        Set(ByVal Value As Boolean)
            mAutoColSize = Value
        End Set
    End Property

#Region "pAutoColSizeF"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoColSizeF
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：自動で列幅設定をする時の開始列。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoColSizeF() As Integer
        Get
            pAutoColSizeF = mAutoColSizeF
        End Get
        Set(ByVal Value As Integer)
            mAutoColSizeF = Value
        End Set
    End Property

#Region "pAutoColSizeT"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoColSizeT
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：自動で列幅設定をする時の終了列。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoColSizeT() As Integer
        Get
            pAutoColSizeT = mAutoColSizeT
        End Get
        Set(ByVal Value As Integer)
            mAutoColSizeT = Value
        End Set

    End Property

    'イベント-------------------------------------------------------------------

    'メソッド-------------------------------------------------------------------
#Region "gSubAutoColSize"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubAutoColSize
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：自動列幅設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubAutoColSize()
        Me.AutoSizeCols(Me.pAutoColSizeF, Me.pAutoColSizeT, UsrFlx.mIntAutoColSpace)
    End Sub

#Region "グリッド設定"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：グリッド設定
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：グリッド設定
    ' 備　考　：通常設定,固定行なしは-1をわたす
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubInitialData( _
            ByVal intCols As Integer _
            , Optional ByVal intRows As Integer = -1 _
            , Optional ByVal intRowSize As Integer = -1 _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnColHedder As Boolean = True _
            , Optional ByVal enmDisplyType As EnmDisplyType = EnmDisplyType.固定行表示 _
            , Optional ByVal EnmHighLight As HighLightEnum = HighLightEnum.Never _
            , Optional ByVal EnmFocusRect As FocusRectEnum = FocusRectEnum.None _
            , Optional ByVal blnEdit As Boolean = False _
            , Optional ByVal intColFrozen As Integer = -1 _
            , Optional ByVal EnmSelectionMode As SelectionModeEnum = SelectionModeEnum.Cell _
            , Optional ByVal EnmSort As AllowSortingEnum = AllowSortingEnum.None _
            , Optional ByVal EnmDragg As AllowDraggingEnum = AllowDraggingEnum.None _
            , Optional ByVal EnmResize As AllowResizingEnum = AllowResizingEnum.None _
            )
        Dim i As Integer

        mTotal = False
        With Me
            .Styles.Highlight.BackColor = System.Drawing.Color.RoyalBlue


            Me.mEnmDisplyType = enmDisplyType
            ''選択形式
            .SelectionMode = EnmSelectionMode
            ''列のドラッグ移動
            .AllowDragging = EnmDragg
            ''セルの編集
            .AllowEditing = blnEdit
            '列幅変更
            .AllowResizing = EnmResize
            ''ソート
            .AllowSorting = EnmSort
            ''ソート印の表示
            .ShowSort = False
            ''選択セルの設定
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''エンターキーの操作しない
            .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''固定行折り返し設定
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''行ヘッダ設定
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''固定行のドラッグは禁止
                    For i = 1 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''固定行のドラッグは禁止
                    For i = 0 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''列ヘッダ設定
            .Rows.Fixed = 2
            If intRows > 0 Then
                .Rows.Count = intRows + 2
            Else
                .Rows.Count = 2
            End If

            ''列ヘッダの表示
            If blnColHedder = False Then
                .Rows(0).Visible = False
                .Rows(1).Visible = False
            End If

            ''行の高さ
            If intRowSize > 0 Then
                .Rows.DefaultSize = intRowSize
                .Rows(0).Height = intRowSize \ 2
                .Rows(1).Height = intRowSize \ 2
            End If

            ''固定行マージ設定
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next

        End With
    End Sub

#Region "グリッド設定(合計行)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：グリッド設定
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：グリッド設定
    ' 備　考　：合計行設定,固定行なしは-1をわたす
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubInitialData_Total( _
            ByVal intCols As Integer _
            , Optional ByVal intRows As Integer = -1 _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnColHedder As Boolean = False _
            , Optional ByVal blnDisplyType As EnmDisplyType = EnmDisplyType.固定行表示 _
            , Optional ByVal blnEdit As Boolean = False _
            , Optional ByVal intColFrozen As Integer = -1 _
            , Optional ByVal EnmSelectionMode As SelectionModeEnum = SelectionModeEnum.Cell _
            , Optional ByVal EnmSort As AllowSortingEnum = AllowSortingEnum.None _
            , Optional ByVal EnmDragg As AllowDraggingEnum = AllowDraggingEnum.None _
            , Optional ByVal EnmResize As AllowResizingEnum = AllowResizingEnum.None _
            , Optional ByVal EnmHighLight As HighLightEnum = HighLightEnum.Always _
            , Optional ByVal EnmFocusRect As FocusRectEnum = FocusRectEnum.Solid _
            )
        Dim i As Integer

        With Me
            ''選択形式
            .SelectionMode = EnmSelectionMode
            ''列のドラッグ移動
            .AllowDragging = EnmDragg
            ''セルの編集
            .AllowEditing = blnEdit
            '列幅変更
            .AllowResizing = EnmResize
            ''ソート
            .AllowSorting = EnmSort
            ''ソート矢印表示
            .ShowSort = False

            ''選択セルの設定
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''エンターキーの操作しない
            .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''固定行折り返し設定
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''行ヘッダ設定
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''固定行のドラッグは禁止
                    For i = 1 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''固定行のドラッグは禁止
                    For i = 0 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''列ヘッダ設定
            .Rows.Fixed = 3
            If intRows > 0 Then
                .Rows.Count = intRows + 3
            Else
                .Rows.Count = 3
            End If
            If blnColHedder = False Then
                .Rows(0).Visible = False
                .Rows(1).Visible = False
            End If

            ''合計行
            Dim style As CellStyle
            style = .Styles.Add(UsrFlx.gCStrTotalName)
            style.BackColor = Color.LightYellow
            style.TextAlign = TextAlignEnum.RightCenter

            For i = 0 To .Cols.Count - 1
                .SetCellStyle(UsrFlx.gCIntTotalRow, i, style)
            Next

            ''固定行マージ設定
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 2
                .Rows(i).AllowMerging = True
            Next
        End With
    End Sub

#Region "列設定"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：列設定
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：列設定
    ' 備　考　：タイトルを２段で表示は vbcrlf で区切る。
    '         :タイトルマージは , で区切る。（frozenの境目とマージが重なるとマージされない)
    '         :固定行を非表示にするとき、マージされている場合列が白くなるので、マージされないように
    '         :ダミーで文字を入れてください。
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubInitialCol( _
         ByVal intCol As Integer _
        , ByVal strTitle As String _
        , ByVal intWith As Integer _
        , Optional ByVal enmAlign As TextAlignEnum = TextAlignEnum.CenterCenter _
        , Optional ByVal blnVisible As Boolean = True _
        , Optional ByVal blnDisplyNum As Boolean = False _
        , Optional ByVal objType As Type = Nothing _
        , Optional ByVal strFormat As String = "" _
        , Optional ByVal blnEdit As Boolean = False _
        , Optional ByVal objMap As Hashtable = Nothing _
        , Optional ByVal strComboList As String = "" _
        , Optional ByVal strMask As String = "" _
        , Optional ByVal blnTotal As Boolean = False _
        , Optional ByVal enmFixedAlign As TextAlignEnum = TextAlignEnum.CenterCenter _
    )
        Dim intP As Integer

        With Me.Cols(intCol)
            ''列設定
            .Name = intCol.ToString
            intP = InStr(strTitle, ",")
            If intP > 0 Then
                Me(0, intCol) = strTitle.Substring(0, intP - 1)
                Me(1, intCol) = strTitle.Substring(intP)
            Else
                Me(0, intCol) = strTitle
                Me(1, intCol) = strTitle
            End If
            '.Caption = strTitle

            ''数値表示
            If blnDisplyNum Then
                .Format = "#,##0"
                .DataType = GetType(Long)
            Else
                .DataType = GetType(String)
            End If

            ''タイプ
            If Not objType Is Nothing Then
                .DataType = objType
            End If

            ''フォーマット
            If strFormat <> "" Then
                .Format = strFormat
            End If

            ''Map設定
            If Not objMap Is Nothing Then
                .DataMap = objMap
            End If

            ''コンボ設定
            If strComboList <> "" Then
                .ComboList = strComboList
            End If

            ''マスク
            If strMask <> "" Then
                .EditMask = strMask
            End If

            .TextAlign = enmAlign
            .TextAlignFixed = enmFixedAlign
            .Width = intWith
            .Visible = blnVisible
            .AllowEditing = blnEdit

            ''合計列
            If blnTotal Then
                Me.mTotal = True
                Me.mTotalColllection.Add(intCol)
            End If
        End With
    End Sub

#Region "gSubSetTotal"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubSetTotal
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：合計列に指定したセルの合計表示
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetTotal()
        Dim i As Integer
        Dim intCol As Integer
        Dim dlbTotal As Double

        For Each intCol In Me.mTotalColllection
            dlbTotal = 0
            For i = Me.pRowCount(EnmRowCount.Enm固定行数) To Me.Rows.Count - 1
                If Me.GetDataDisplay(i, intCol).TrimEnd <> "" Then
                    dlbTotal = dlbTotal + CDbl(Me.GetData(i, intCol))
                End If
            Next
            Me(UsrFlx.gCIntTotalRow, intCol) = Format(dlbTotal, Me.Cols(intCol).Format)
        Next
        Me.Rows(UsrFlx.gCIntTotalRow).StyleNew.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

#Region "gSubClearTotal"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubClearTotal
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：合計列に指定したセルのクリア
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubClearTotal()
        Dim intCol As Integer

        For Each intCol In Me.mTotalColllection
            Me(UsrFlx.gCIntTotalRow, intCol) = ""
        Next

    End Sub

#Region "gSubSelectDelete"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubSelectDelete
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：現在選択されている行を削除する。複数選択モードのとき使用する。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSelectDelete()
        Dim objRow As Row

        For Each objRow In Me.Rows.Selected
            Me.Rows.Remove(objRow.Index)
        Next

    End Sub

#Region "gSubTotalCollectionDelete"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubTotalCollectionDelete
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：mTotalColllectionを削除する。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubTotalCollectionDelete()
        Do Until Me.mTotalColllection.Count = 0
            Me.mTotalColllection.Remove(Me.mTotalColllection.Count)
        Loop
        Me.mTotal = False

    End Sub

#Region "gSubRowHedderRenumber"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubRowHedderRenumber
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：Rowヘッダーのn何行目の番号を振りなおす
    ' 備　考　：行数がかわったときなどでヘッダの番号をふりなおす
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubRowHedderRenumber(Optional ByVal intCol As Integer = 0)
        Dim i As Integer
        Dim intNum As Integer

        For i = Me.pRowCount To Me.Rows.Count - 1
            intNum += 1
            Me.SetData(i, intCol, intNum)
        Next
    End Sub

#Region "gSubClear"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubClear
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：表示のセルを消去する
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubCellClear()
        Dim i As Integer
        Dim j As Integer
        For i = Me.pRowCount To Me.Rows.Count - 1
            For j = 0 To Me.Cols.Count - 1
                Me(i, j) = ""
            Next
        Next
    End Sub

    ''テスト用
    Public Sub gSubColイミディエイト()
        Dim i As Integer
        For i = 0 To Me.Cols.Count - 1
            Debug.WriteLine(CStr(i) & ":" & Me.Cols(i).Width)
        Next
    End Sub

End Class
