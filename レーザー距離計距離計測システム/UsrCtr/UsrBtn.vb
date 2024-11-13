'*******************************************************************************
' @(h)  UsrBtn.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrBtn                             System.Windows.Forms.Buttonを継承
'       初期設定される作成プロパティー
'       pMoveForm = enmMoveForm.AllCloseOpen
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Option Explicit On 
Public Class UsrBtn
    Inherits System.Windows.Forms.Button

    Private mBtnID As String
    Private mFuncKey As String
    Private mMoveForm As enmMoveForm
    Private mFocusColor As New System.Drawing.Color()
    Private mBlnClear As Boolean

    Public Enum enmMoveForm
        AllCloseOpen   'すべての子フォームを閉じてpBtnID画面を表示
        NotCloseOpen   '画面を閉じずにpBtnID画面を表示
        MeCloseIDopen  '自分は閉じてpBtnID画面を表示
        IDActiveOpen   'pBtnID画面がすでに開いていたらアクティブ、開いてない場合は開く
    End Enum

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.mBtnID = ""
        Me.mFuncKey = ""
        Me.mMoveForm = enmMoveForm.AllCloseOpen
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        ''フォーカス時の色
        Me.mFocusColor = System.Drawing.Color.LightGreen
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
        'UsrBtn
        '

    End Sub

#End Region

    ''プロパティー-------------------------------------------------------------------
#Region "pFuncKeyプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFuncKeyプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：割り当てるファンクションキー
    ' 備　考　：（例　F1を割り当てる。"F1"。SHIFT+F1を割り当てる。"SF1"
    '---------------------------------------------------------------------------
#End Region
    Public Property pFuncKey() As String
        Get
            pFuncKey = mFuncKey
        End Get
        Set(ByVal Value As String)
            mFuncKey = Value
        End Set
    End Property

#Region "pMoveFormプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMoveFormプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：画面移動するときの制御をする。
    ' 備　考　：移動方法はenmMoveFormを参照
    '---------------------------------------------------------------------------
#End Region
    Public Property pMoveForm() As enmMoveForm
        Get
            pMoveForm = mMoveForm
        End Get
        Set(ByVal Value As enmMoveForm)
            mMoveForm = Value
        End Set
    End Property

#Region "pBtnIDプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pBtnIDプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：移動画面IDの取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pBtnID() As String
        Get
            pBtnID = mBtnID
        End Get
        Set(ByVal Value As String)
            mBtnID = Value
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

    ''オーバーライド-------------------------------------------------------------------
#Region "フォーカス取得時の色変更(オーバーライド)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：フォーカス取得時の色変更
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス取得時の色変更
    ' 備　考　：オーバーライド
    '---------------------------------------------------------------------------
#End Region
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnGotFocus(e)
    End Sub

#Region "フォーカス消失時の色変更(オーバーライド)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：フォーカス消失時の色変更
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォーカス消失時の色変更
    ' 備　考　：オーバーライド
    '---------------------------------------------------------------------------
#End Region
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        'Me.BackColor = Me.DefaultBackColor
    End Sub

#Region "標準サイズ(オーバーライド)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：標準サイズ
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォームにボタンを配置したときの標準サイズの変更
    ' 備　考　：オーバーライド
    '---------------------------------------------------------------------------
#End Region
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            DefaultSize = New System.Drawing.Size(73, 33)
        End Get
    End Property
End Class
