'*******************************************************************************
' @(h)  UsrCmb.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrCmb                             System.Windows.Forms.ComboBoxを継承
'       初期設定される作成プロパティー
'       pCharType = Me.EnmCharType.All
'       pAutoFocus = True
'       pAutoSelect = True
'       pClearIndex = -1
'       pCondition = EnmCondition.Nomal
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrCmb
    Inherits System.Windows.Forms.ComboBox

    Public Enum EnmCharType
        Numonly     '数字のみ
        Letter      '文字のみ
        All         '入力制限なし
        WildNumonly     '数字のみ + *
        WildLetter      '文字のみ + *
        WildNumLetter   '文字＆数字 + *
    End Enum

    Public Enum EnmCondition
        Nomal       '入力許可
        Fuka        '入力不可
        Hissu       '必須入力
        Impact      '強調(目立つ色を使用する)
    End Enum

    Public Enum EnmFromTo
        None    ''なし
        Num     ''数値
        Letter  ''文字
    End Enum

    Private mStrErrText As String
    Private mStrFromToErrText As String
    Private mMaxByte As Integer
    Private mIntClearIndex As Integer
    Private mFromToSearch As EnmFromTo
    Private mBlnAutoFocus As Boolean
    Private mBlnAutoSelect As Boolean
    Private mCharType As EnmCharType
    Private mCondition As EnmCondition
    Private mHissuColor As New System.Drawing.Color
    Private mImpactColor As New System.Drawing.Color
    Private mObjFrom As Object
    Private mValueCollection As New Collection()
    Private mStrClearText As String
    Private mBlnClear As Boolean

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.mStrErrText = ""
        Me.mStrFromToErrText = ""
        Me.mStrClearText = ""
        Me.mIntClearIndex = -1
        Me.mBlnAutoFocus = True
        Me.mBlnAutoSelect = True
        Me.mCharType = UsrCmb.EnmCharType.All
        Me.mCondition = UsrCmb.EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.pIsClear = True
    End Sub

    'UserControl はコンポーネント一覧を消去するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    ' Windows フォーム デザイナを使って変更してください。  
    ' コード エディタは使用しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'UsrCmb
        '
        Me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "pValuesText(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pValuesText
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：Itemsの選択されているインデックから同じ位置にあるpValuesのテキストの取得
    ' 備　考　：コレクションのインデックスは１からはじまるので、itemsと１つづれます。
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pValuesText(ByVal intIndex As Integer) As String
        Get
            If intIndex = -1 Then
                pValuesText = ""
            Else
                pValuesText = CStr(Me.mValueCollection.Item(intIndex + 1))
            End If
        End Get
    End Property

#Region "pValues"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pValues
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：Itemsのインデックス+1の位置に対になる値をいれる。
    ' 備　考　：コレクションのインデックスは１からはじまるので、itemsと１つづれます。
    '---------------------------------------------------------------------------
#End Region
    Public Property pValues() As Collection
        Get
            pValues = Me.mValueCollection
        End Get
        Set(ByVal Value As Collection)
            Me.mValueCollection = Value
        End Set
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

#Region "pClearTextプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pClearTextプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期表示するtextプロパティーの取得設定
    ' 備　考　：ドロップダウン形式時の初期表示する。テキストの取得設定
    '---------------------------------------------------------------------------
#End Region
    Public Property pClearText() As String
        Get
            pClearText = mStrClearText
        End Get
        Set(ByVal Value As String)
            mStrClearText = Value
        End Set
    End Property

#Region "pClearIndexプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pClearIndexプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期表示するindexプロパティーの取得設定
    ' 備　考　：リストボックス形式時に初期表示するインデックスの取得設定
    '---------------------------------------------------------------------------
#End Region
    Public Property pClearIndex() As Integer
        Get
            pClearIndex = mIntClearIndex
        End Get
        Set(ByVal Value As Integer)
            mIntClearIndex = Value
        End Set
    End Property

#Region "pMaxByte"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMaxByte
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力できるバイト数(0は無制限)
    ' 備　考　：MaxLengthプロパティーは文字数の制限になるので使用しないで下さい。
    '---------------------------------------------------------------------------
#End Region
    Public Property pMaxByte() As Integer
        Get
            pMaxByte = Me.mMaxByte
        End Get
        Set(ByVal Value As Integer)
            Me.mMaxByte = Value
        End Set
    End Property

#Region "pAutoFocusプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoFocusプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：pMaxbyteのバイト数入力時に次のコントロールに移動するか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoFocus() As Boolean
        Get
            pAutoFocus = Me.mBlnAutoFocus
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnAutoFocus = Value
        End Set
    End Property

#Region "pAutoSelectプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pAutoSelectプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス取得時に文字選択するか
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pAutoSelect() As Boolean
        Get
            pAutoSelect = Me.mBlnAutoSelect
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnAutoSelect = Value
        End Set
    End Property

#Region "pCharTypeプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pCharTypeプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力文字制限
    ' 備　考　：EnmCharTypeを参照
    '---------------------------------------------------------------------------
#End Region
    Public Property pCharType() As EnmCharType
        Get
            pCharType = Me.mCharType
        End Get
        Set(ByVal Value As EnmCharType)
            Me.mCharType = Value
        End Set
    End Property

#Region "pConditionプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pConditionプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力状態,背景色変更
    ' 備　考　：EnmConditionを参照
    '---------------------------------------------------------------------------
#End Region
    Public Property pCondition() As EnmCondition
        Get
            pCondition = mCondition
        End Get
        Set(ByVal Value As EnmCondition)
            mCondition = Value
            Select Case Me.mCondition
                Case EnmCondition.Nomal
                    Me.Enabled = True
                    Me.BackColor = System.Drawing.SystemColors.Window
                Case EnmCondition.Fuka
                    Me.Enabled = False
                    Me.BackColor = System.Drawing.SystemColors.Control
                Case EnmCondition.Hissu
                    Me.Enabled = True
                    Me.BackColor = mHissuColor
                Case EnmCondition.Impact
                    Me.Enabled = True
                    Me.BackColor = mImpactColor
            End Select
        End Set
    End Property

#Region "pErrTextプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pErrTextプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力エラー時に表示される
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pErrText() As String
        Get
            pErrText = mStrErrText
        End Get
        Set(ByVal Value As String)
            mStrErrText = Value
        End Set
    End Property

#Region "pFromToSearchプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFromToSearchプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FromToのEnmFromToで行う
    ' 備　考　：pFromObjに割り付けたコントロールとの範囲検索を行う
    '---------------------------------------------------------------------------
#End Region
    Public Property pFromToSearch() As EnmFromTo
        Get
            pFromToSearch = mFromToSearch
        End Get
        Set(ByVal Value As EnmFromTo)
            mFromToSearch = Value
        End Set
    End Property

#Region "pFromObjプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFromObjプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FromToの検索を行うか時のFromオブジェクト
    ' 備　考　：同じ型のコントロールでの範囲検索をします。
    '---------------------------------------------------------------------------
#End Region
    Public Property pFromObj() As Object
        Get
            pFromObj = mObjFrom
        End Get
        Set(ByVal Value As Object)
            mObjFrom = Value
        End Set
    End Property

#Region "pFromToErrTextプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFromToErrTextプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FromTo範囲入力エラー時に表示される
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pFromToErrText() As String
        Get
            pFromToErrText = mStrFromToErrText
        End Get
        Set(ByVal Value As String)
            mStrFromToErrText = Value
        End Set
    End Property

    ''イベント処理-------------------------------------------------------------------
#Region "TextChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：TextChanged
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：最大桁数でタブキーの動作
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
    End Sub

#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：Enter
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス取得時に文字選択
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        If Me.mBlnAutoFocus And Me.DropDownStyle = ComboBoxStyle.DropDownList Then
            Me.SelectAll()
        End If
    End Sub

#Region "SizeChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：SizeChanged
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：ドロップダウンの幅をコントロールの幅に合わせる
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.DropDownWidth = Me.Width
    End Sub

#Region "KeyPress"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：KeyPress
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力文字をChrTypeにより制限します
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim intByte As Integer
        Dim intMoji As Integer

        ''編集可能時のみ
        If Me.DropDownStyle = ComboBoxStyle.DropDown Then
            ''Maxlength
            intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text)
            intMoji = Me.pMaxByte - intByte
            If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(e.KeyChar) = 2 Then
                If intMoji = 1 Then
                    Me.MaxLength = Me.Text.Length
                Else
                    Me.MaxLength = Me.Text.Length + intMoji
                End If
            Else
                Me.MaxLength = Me.Text.Length + intMoji
            End If
        End If
    End Sub

    ''メソッド------------------------------------------------------------------
#Region "gSubComboClear"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubComboClear
    ' 引　数　：blnTextClear textプロパティーをクリアするか
    ' 戻り値　：
    ' 機能説明：Items,pValuesに割り当てられている項目をすべて削除します。
    ' 備　考　：ドロップダウン形式時に、textも同時にpClearTextプロパティーの値にします。
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubComboClear(Optional ByVal blnTextClear As Boolean = True)

        Me.Items.Clear()
        Do Until Me.pValues.Count = 0
            Me.pValues.Remove(Me.pValues.Count)
        Loop

        If blnTextClear Then
            If Me.DropDownStyle = ComboBoxStyle.DropDown Then
                Me.Text = Me.pClearText
            End If
        End If
    End Sub

#Region "gIntFindValue"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gIntFindValue
    ' 引　数　：strSearch
    ' 戻り値　：
    ' 機能説明：strSearchからはじめに見つけたインデックスをpValuesから取得する
    ' 備　考　：インデックスはItemsと対になるように-1されています。
    '---------------------------------------------------------------------------
#End Region
    Public Function gIntFindValue(ByVal strSearch As String) As Integer
        Dim i As Integer

        For i = 1 To Me.pValues.Count
            If CStr(Me.pValues.Item(i)) = strSearch Then
                Return i - 1
            End If
        Next
        Return -1
    End Function

#Region "gSubSetItemIndex"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：コンボの文字列に一致する行を選択
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：コンボの文字列に一致する行を選択。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetItemIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.FindStringExact(strValue)
    End Sub

#Region "gSubSetValueIndex"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：コンボのコレクションに一致する行を選択
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：コンボのコレクションに一致する行を選択
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetValueIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.gIntFindValue(strValue)
    End Sub

End Class
