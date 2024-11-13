'*******************************************************************************
' @(h)  UsrMnuitem.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrMnuitem                             System.Windows.Forms.MenuItemを継承
'       
'*******************************************************************************
Option Explicit On 
Public Class UsrMnuitem
    Inherits System.Windows.Forms.MenuItem

    Private mFormID As String
    Private mMnuName As String

    ''プロパティー-------------------------------------------------------------------
#Region "pFormIDプロパティー"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pFormIDプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：表示する画面IDの取得設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pFormID() As String
        Get
            pFormID = Me.mFormID
        End Get
        Set(ByVal Value As String)
            Me.mFormID = Value
        End Set
    End Property

#Region "pMnuName"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pMnuNameプロパティー
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：親メニューの表示はTEXTプロパティーへ、隠しで画面名をセットする。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pMnuName() As String
        Get
            pMnuName = Me.mMnuName
        End Get
        Set(ByVal Value As String)
            Me.mMnuName = Value
        End Set
    End Property
End Class
