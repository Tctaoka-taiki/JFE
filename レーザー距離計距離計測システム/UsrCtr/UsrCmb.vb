'*******************************************************************************
' @(h)  UsrCmb.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrCmb                             System.Windows.Forms.ComboBox���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pCharType = Me.EnmCharType.All
'       pAutoFocus = True
'       pAutoSelect = True
'       pClearIndex = -1
'       pCondition = EnmCondition.Nomal
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Public Class UsrCmb
    Inherits System.Windows.Forms.ComboBox

    Public Enum EnmCharType
        Numonly     '�����̂�
        Letter      '�����̂�
        All         '���͐����Ȃ�
        WildNumonly     '�����̂� + *
        WildLetter      '�����̂� + *
        WildNumLetter   '���������� + *
    End Enum

    Public Enum EnmCondition
        Nomal       '���͋���
        Fuka        '���͕s��
        Hissu       '�K�{����
        Impact      '����(�ڗ��F���g�p����)
    End Enum

    Public Enum EnmFromTo
        None    ''�Ȃ�
        Num     ''���l
        Letter  ''����
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

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.mStrErrText = ""
        Me.mStrFromToErrText = ""
        Me.mStrClearText = ""
        Me.mIntClearIndex = -1
        Me.mBlnAutoFocus = True
        Me.mBlnAutoSelect = True
        Me.mCharType = UsrCmb.EnmCharType.All
        Me.mCondition = UsrCmb.EnmCondition.Nomal
        Me.mFromToSearch = EnmFromTo.None
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.mImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.pIsClear = True
    End Sub

    'UserControl �̓R���|�[�l���g�ꗗ���������邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    ' Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^�͎g�p���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'UsrCmb
        '
        Me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

    End Sub

#End Region

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "pValuesText(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpValuesText
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FItems�̑I������Ă���C���f�b�N���瓯���ʒu�ɂ���pValues�̃e�L�X�g�̎擾
    ' ���@�l�@�F�R���N�V�����̃C���f�b�N�X�͂P����͂��܂�̂ŁAitems�ƂP�Â�܂��B
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
    ' �@�@�\�@�FpValues
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FItems�̃C���f�b�N�X+1�̈ʒu�ɑ΂ɂȂ�l�������B
    ' ���@�l�@�F�R���N�V�����̃C���f�b�N�X�͂P����͂��܂�̂ŁAitems�ƂP�Â�܂��B
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

#Region "pIsClear�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpIsClear�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F����������Ƃ��ɂ�Text�v���p�e�B�[�����������邩�ǂ���
    ' ���@�l�@�F
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

#Region "pClearText�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpClearText�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����\������text�v���p�e�B�[�̎擾�ݒ�
    ' ���@�l�@�F�h���b�v�_�E���`�����̏����\������B�e�L�X�g�̎擾�ݒ�
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

#Region "pClearIndex�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpClearIndex�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����\������index�v���p�e�B�[�̎擾�ݒ�
    ' ���@�l�@�F���X�g�{�b�N�X�`�����ɏ����\������C���f�b�N�X�̎擾�ݒ�
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
    ' �@�@�\�@�FpMaxByte
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͂ł���o�C�g��(0�͖�����)
    ' ���@�l�@�FMaxLength�v���p�e�B�[�͕������̐����ɂȂ�̂Ŏg�p���Ȃ��ŉ������B
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

#Region "pAutoFocus�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpAutoFocus�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FpMaxbyte�̃o�C�g�����͎��Ɏ��̃R���g���[���Ɉړ����邩
    ' ���@�l�@�F
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

#Region "pAutoSelect�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpAutoSelect�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�擾���ɕ����I�����邩
    ' ���@�l�@�F
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

#Region "pCharType�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpCharType�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͕�������
    ' ���@�l�@�FEnmCharType���Q��
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

#Region "pCondition�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpCondition�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͏��,�w�i�F�ύX
    ' ���@�l�@�FEnmCondition���Q��
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

#Region "pErrText�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpErrText�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���̓G���[���ɕ\�������
    ' ���@�l�@�F
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

#Region "pFromToSearch�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFromToSearch�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FFromTo��EnmFromTo�ōs��
    ' ���@�l�@�FpFromObj�Ɋ���t�����R���g���[���Ƃ͈̔͌������s��
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

#Region "pFromObj�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFromObj�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FFromTo�̌������s��������From�I�u�W�F�N�g
    ' ���@�l�@�F�����^�̃R���g���[���ł͈̔͌��������܂��B
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

#Region "pFromToErrText�v���p�e�B�["
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpFromToErrText�v���p�e�B�[
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FFromTo�͈͓��̓G���[���ɕ\�������
    ' ���@�l�@�F
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

    ''�C�x���g����-------------------------------------------------------------------
#Region "TextChanged"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FTextChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�ő包���Ń^�u�L�[�̓���
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
    End Sub

#Region "Enter"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FEnter
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�J�X�擾���ɕ����I��
    ' ���@�l�@�F
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
    ' �@�@�\�@�FSizeChanged
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�h���b�v�_�E���̕����R���g���[���̕��ɍ��킹��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.DropDownWidth = Me.Width
    End Sub

#Region "KeyPress"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FKeyPress
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���͕�����ChrType�ɂ�萧�����܂�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub UsrCmb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim intByte As Integer
        Dim intMoji As Integer

        ''�ҏW�\���̂�
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

    ''���\�b�h------------------------------------------------------------------
#Region "gSubComboClear"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubComboClear
    ' ���@���@�FblnTextClear text�v���p�e�B�[���N���A���邩
    ' �߂�l�@�F
    ' �@�\�����FItems,pValues�Ɋ��蓖�Ă��Ă��鍀�ڂ����ׂč폜���܂��B
    ' ���@�l�@�F�h���b�v�_�E���`�����ɁAtext��������pClearText�v���p�e�B�[�̒l�ɂ��܂��B
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
    ' �@�@�\�@�FgIntFindValue
    ' ���@���@�FstrSearch
    ' �߂�l�@�F
    ' �@�\�����FstrSearch����͂��߂Ɍ������C���f�b�N�X��pValues����擾����
    ' ���@�l�@�F�C���f�b�N�X��Items�Ƒ΂ɂȂ�悤��-1����Ă��܂��B
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
    ' �@�@�\�@�F�R���{�̕�����Ɉ�v����s��I��
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�R���{�̕�����Ɉ�v����s��I���B
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetItemIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.FindStringExact(strValue)
    End Sub

#Region "gSubSetValueIndex"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�R���{�̃R���N�V�����Ɉ�v����s��I��
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�R���{�̃R���N�V�����Ɉ�v����s��I��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetValueIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.gIntFindValue(strValue)
    End Sub

End Class
