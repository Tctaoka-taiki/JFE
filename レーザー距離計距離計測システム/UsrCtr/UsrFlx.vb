'*******************************************************************************
' @(h)  UsrFlx.vb
'                                           Ver.1.0 (            T.TADA )
'       **  Version 2.6.20071.324 ���g�p **
'       C1.Common   ,c1.win.c1flexgrid  �̎Q�ƒǉ����K�v�ł�
'
'
' @(s)  UsrFlx                             C1.Win.C1FlexGrid.C1FlexGrid���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pCondition = EnmCondition.Nomal
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       Styles.Frozen.BackColor = Color.Beige
'       Styles.Alternate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
'       Styles.Fixed.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Option Explicit On 
Imports C1.Win.C1FlexGrid
Public Class UsrFlx
    Inherits C1.Win.C1FlexGrid.C1FlexGrid

    Public Const gCStrTotalName As String = "TOTAL"
    Public Const gCIntTotalRow As Integer = 2

    Private Const mIntAutoColSpace As Integer = 5   '�����񕝐ݒ�g�p���̗]����
    Private mAutoColSizeF As Integer
    Private mAutoColSizeT As Integer
    Private mAutoColSize As Boolean
    Private mTotal As Boolean
    Private mTotalColllection As New Collection()
    Private mBlnClear As Boolean 
    Private mDclicBtn As UsrBtn
    Private mEnmDisplyType As EnmDisplyType = EnmDisplyType.�Œ�s�\��

    Public Enum EnmDisplyType
        �ʏ�         '�\���s�������s�������Ă���
        �Œ�s�\��   '��ɕ\���̍s��������(�G�N�Z���^�C�v)
    End Enum

    Public Enum EnmRowCount
        Enm�\���s��
        Enm�Œ�s��
    End Enum

#Region " �R���|�[�l���g �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���́A�R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Styles.Frozen.BackColor = Color.Beige
        Me.Styles.Alternate.BackColor = System.Drawing.Color.White
        Me.Styles.Fixed.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
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

    'Control �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂ɁAdispose �����s���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    '�R���g���[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���̓R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
    ' �R���|�[�l���g �f�U�C�i���g���ĕύX�ł��܂��B�R�[�h �G�f�B�^��
    ' �g���ĕύX���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    ''�v���p�e�B�[-------------------------------------------------------------------
#Region "pDisply(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpDisply
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�\���s�̗L��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pDisply() As Boolean
        Get
            If Me.Rows.Count = Me.pRowCount(EnmRowCount.Enm�Œ�s��) Then
                pDisply = False
            Else
                pDisply = True
            End If
        End Get
    End Property

#Region "pTotal(ReadOnly)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpTotal
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���v�s�̗L��
    ' ���@�l�@�F
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
    ' �@�@�\�@�FpRowCount
    ' ���@���@�FEnmRowCount
    ' �߂�l�@�F�Œ�s���܂��͕\���s��
    ' �@�\�����F�Œ�s���܂��͕\���s���̎擾
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public ReadOnly Property pRowCount(Optional ByVal EnmRowCount As EnmRowCount = EnmRowCount.Enm�Œ�s��) As Integer
        Get
            Select Case EnmRowCount
                Case EnmRowCount.Enm�Œ�s��
                    pRowCount = Me.Rows.Fixed + Me.Rows.Frozen
                Case EnmRowCount.Enm�\���s��
                    pRowCount = Me.Rows.Count - (Me.Rows.Fixed + Me.Rows.Frozen)
            End Select
        End Get
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

#Region "pDisplyType"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpDisplyType
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�\���̌`��
    ' ���@�l�@�F
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
    ' �@�@�\�@�FpAutoColSize
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����ŗ񕝐ݒ�����邩�B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FpAutoColSizeF
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����ŗ񕝐ݒ�����鎞�̊J�n��B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FpAutoColSizeT
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����ŗ񕝐ݒ�����鎞�̏I����B
    ' ���@�l�@�F
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

    '�C�x���g-------------------------------------------------------------------

    '���\�b�h-------------------------------------------------------------------
#Region "gSubAutoColSize"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubAutoColSize
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�����񕝐ݒ�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubAutoColSize()
        Me.AutoSizeCols(Me.pAutoColSizeF, Me.pAutoColSizeT, UsrFlx.mIntAutoColSpace)
    End Sub

#Region "�O���b�h�ݒ�"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�O���b�h�ݒ�
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�O���b�h�ݒ�
    ' ���@�l�@�F�ʏ�ݒ�,�Œ�s�Ȃ���-1���킽��
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubInitialData( _
            ByVal intCols As Integer _
            , Optional ByVal intRows As Integer = -1 _
            , Optional ByVal intRowSize As Integer = -1 _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnColHedder As Boolean = True _
            , Optional ByVal enmDisplyType As EnmDisplyType = EnmDisplyType.�Œ�s�\�� _
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
            ''�I���`��
            .SelectionMode = EnmSelectionMode
            ''��̃h���b�O�ړ�
            .AllowDragging = EnmDragg
            ''�Z���̕ҏW
            .AllowEditing = blnEdit
            '�񕝕ύX
            .AllowResizing = EnmResize
            ''�\�[�g
            .AllowSorting = EnmSort
            ''�\�[�g��̕\��
            .ShowSort = False
            ''�I���Z���̐ݒ�
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''�G���^�[�L�[�̑��삵�Ȃ�
            .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''�Œ�s�܂�Ԃ��ݒ�
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''�s�w�b�_�ݒ�
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 1 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 0 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''��w�b�_�ݒ�
            .Rows.Fixed = 2
            If intRows > 0 Then
                .Rows.Count = intRows + 2
            Else
                .Rows.Count = 2
            End If

            ''��w�b�_�̕\��
            If blnColHedder = False Then
                .Rows(0).Visible = False
                .Rows(1).Visible = False
            End If

            ''�s�̍���
            If intRowSize > 0 Then
                .Rows.DefaultSize = intRowSize
                .Rows(0).Height = intRowSize \ 2
                .Rows(1).Height = intRowSize \ 2
            End If

            ''�Œ�s�}�[�W�ݒ�
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next

        End With
    End Sub

#Region "�O���b�h�ݒ�(���v�s)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�O���b�h�ݒ�
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�O���b�h�ݒ�
    ' ���@�l�@�F���v�s�ݒ�,�Œ�s�Ȃ���-1���킽��
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubInitialData_Total( _
            ByVal intCols As Integer _
            , Optional ByVal intRows As Integer = -1 _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnColHedder As Boolean = False _
            , Optional ByVal blnDisplyType As EnmDisplyType = EnmDisplyType.�Œ�s�\�� _
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
            ''�I���`��
            .SelectionMode = EnmSelectionMode
            ''��̃h���b�O�ړ�
            .AllowDragging = EnmDragg
            ''�Z���̕ҏW
            .AllowEditing = blnEdit
            '�񕝕ύX
            .AllowResizing = EnmResize
            ''�\�[�g
            .AllowSorting = EnmSort
            ''�\�[�g���\��
            .ShowSort = False

            ''�I���Z���̐ݒ�
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''�G���^�[�L�[�̑��삵�Ȃ�
            .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''�Œ�s�܂�Ԃ��ݒ�
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''�s�w�b�_�ݒ�
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 1 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 0 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''��w�b�_�ݒ�
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

            ''���v�s
            Dim style As CellStyle
            style = .Styles.Add(UsrFlx.gCStrTotalName)
            style.BackColor = Color.LightYellow
            style.TextAlign = TextAlignEnum.RightCenter

            For i = 0 To .Cols.Count - 1
                .SetCellStyle(UsrFlx.gCIntTotalRow, i, style)
            Next

            ''�Œ�s�}�[�W�ݒ�
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 2
                .Rows(i).AllowMerging = True
            Next
        End With
    End Sub

#Region "��ݒ�"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F��ݒ�
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F��ݒ�
    ' ���@�l�@�F�^�C�g�����Q�i�ŕ\���� vbcrlf �ŋ�؂�B
    '         :�^�C�g���}�[�W�� , �ŋ�؂�B�ifrozen�̋��ڂƃ}�[�W���d�Ȃ�ƃ}�[�W����Ȃ�)
    '         :�Œ�s���\���ɂ���Ƃ��A�}�[�W����Ă���ꍇ�񂪔����Ȃ�̂ŁA�}�[�W����Ȃ��悤��
    '         :�_�~�[�ŕ��������Ă��������B
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
            ''��ݒ�
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

            ''���l�\��
            If blnDisplyNum Then
                .Format = "#,##0"
                .DataType = GetType(Long)
            Else
                .DataType = GetType(String)
            End If

            ''�^�C�v
            If Not objType Is Nothing Then
                .DataType = objType
            End If

            ''�t�H�[�}�b�g
            If strFormat <> "" Then
                .Format = strFormat
            End If

            ''Map�ݒ�
            If Not objMap Is Nothing Then
                .DataMap = objMap
            End If

            ''�R���{�ݒ�
            If strComboList <> "" Then
                .ComboList = strComboList
            End If

            ''�}�X�N
            If strMask <> "" Then
                .EditMask = strMask
            End If

            .TextAlign = enmAlign
            .TextAlignFixed = enmFixedAlign
            .Width = intWith
            .Visible = blnVisible
            .AllowEditing = blnEdit

            ''���v��
            If blnTotal Then
                Me.mTotal = True
                Me.mTotalColllection.Add(intCol)
            End If
        End With
    End Sub

#Region "gSubSetTotal"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubSetTotal
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���v��Ɏw�肵���Z���̍��v�\��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetTotal()
        Dim i As Integer
        Dim intCol As Integer
        Dim dlbTotal As Double

        For Each intCol In Me.mTotalColllection
            dlbTotal = 0
            For i = Me.pRowCount(EnmRowCount.Enm�Œ�s��) To Me.Rows.Count - 1
                If Me.GetDataDisplay(i, intCol).TrimEnd <> "" Then
                    dlbTotal = dlbTotal + CDbl(Me.GetData(i, intCol))
                End If
            Next
            Me(UsrFlx.gCIntTotalRow, intCol) = Format(dlbTotal, Me.Cols(intCol).Format)
        Next
        Me.Rows(UsrFlx.gCIntTotalRow).StyleNew.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

#Region "gSubClearTotal"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FgSubClearTotal
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���v��Ɏw�肵���Z���̃N���A
    ' ���@�l�@�F
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
    ' �@�@�\�@�FgSubSelectDelete
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F���ݑI������Ă���s���폜����B�����I�����[�h�̂Ƃ��g�p����B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FgSubTotalCollectionDelete
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FmTotalColllection���폜����B
    ' ���@�l�@�F
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
    ' �@�@�\�@�FgSubRowHedderRenumber
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����FRow�w�b�_�[��n���s�ڂ̔ԍ���U��Ȃ���
    ' ���@�l�@�F�s������������Ƃ��ȂǂŃw�b�_�̔ԍ����ӂ�Ȃ���
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
    ' �@�@�\�@�FgSubClear
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�\���̃Z������������
    ' ���@�l�@�F
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

    ''�e�X�g�p
    Public Sub gSubCol�C�~�f�B�G�C�g()
        Dim i As Integer
        For i = 0 To Me.Cols.Count - 1
            Debug.WriteLine(CStr(i) & ":" & Me.Cols(i).Width)
        Next
    End Sub

End Class
