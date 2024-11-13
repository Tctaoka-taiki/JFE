'*******************************************************************************
' @(h)  UsrOpt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrOpt                             System.Windows.Forms.RadioButtonを継承
'       初期設定される作成プロパティー
'       
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrOpt
    Inherits System.Windows.Forms.RadioButton

    Private mBlnClearChecked As Boolean
    Private mBlnClear As Boolean 
    Private mFocusColor As New System.Drawing.Color
    Private mDefaultColor As New System.Drawing.Color
    Private mOptID As String

#Region " コンポーネント デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.mOptID = ""
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.pIsClear = True
        ''フォーカス時の色
        Me.mFocusColor = System.Drawing.Color.Yellow
        Me.mDefaultColor = Me.BackColor
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
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
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

#Region "pClearCheckedプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pClearCheckedプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期表示のをCheckd
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pClearChecked() As Boolean
        Get
            pClearChecked = Me.mBlnClearChecked
        End Get
        Set(ByVal Value As Boolean)
            Me.mBlnClearChecked = Value
        End Set
    End Property

#Region "pDefBackcolor"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pDefBackcolor
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：初期の色
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pDefBackcolor() As Color
        Get
            Return mDefaultColor
        End Get
        Set(ByVal Value As Color)
            Me.mDefaultColor = Value
        End Set
    End Property

#Region "pOptIDプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pOptIDプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：IDの取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pOptID() As String
        Get
            pOptID = mOptID
        End Get
        Set(ByVal Value As String)
            mOptID = Value
        End Set
    End Property

    ''オーバーライド-------------------------------------------------------------------
    Protected Overrides Sub OnCheckedChanged(ByVal e As System.EventArgs)
        MyBase.OnCheckedChanged(e)
        If Me.Appearance = Windows.Forms.Appearance.Button Then
            If Me.Checked Then
                Me.BackColor = Me.mFocusColor
            Else
                Me.BackColor = Me.mDefaultColor
            End If
        End If
    End Sub
End Class
