'*******************************************************************************
' @(h)  UsrLbl.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrLbl                             System.Windows.Forms.Labelを継承
'       初期設定される作成プロパティー
'       
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ForeColor = System.Drawing.SystemColors.ControlText
'       TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrLbl
    Inherits System.Windows.Forms.Label

    Private mLblID As String
    Private mBlnClear As Boolean
    Private mStrClearText As String
    Private mMaxInt As Integer = 5
    Private mMaxDec As Integer = 0
    Private mCharType As EnmCharType = EnmCharType.Numonly

    Public Enum EnmCharType
        Numonly     '数字
        Letter      '文字
    End Enum

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.mLblID = ""
        Me.mStrClearText = ""
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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

    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "pmMaxInt"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pmMaxInt
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力できる整数の数値桁数
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pMaxInt() As Integer
        Get
            pMaxInt = Me.mMaxInt
        End Get
        Set(ByVal Value As Integer)
            Me.mMaxInt = Value
        End Set
    End Property

#Region "pMaxDec"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMaxDec
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：入力できる小数点以下の数値桁数
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pMaxDec() As Integer
        Get
            pMaxDec = Me.mMaxDec
        End Get
        Set(ByVal Value As Integer)
            Me.mMaxDec = Value
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
    ' 機能説明：初期表示するtext
    ' 備　考　：
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

#Region "pLblIDプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pLblIDプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pLblID() As String
        Get
            pLblID = mLblID
        End Get
        Set(ByVal Value As String)
            mLblID = Value
        End Set
    End Property

End Class
