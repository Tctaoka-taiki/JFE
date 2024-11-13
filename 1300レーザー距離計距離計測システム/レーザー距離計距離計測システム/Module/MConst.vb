'*******************************************************************************
' @(h)  MConst.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  �O���[�o���萔
'*******************************************************************************
Imports System.Drawing

Public Module MConst

#Region "�e�[�u��"
    ''�f�[�^�t�@�C��
    Public Const TBL���H�t�@�C�� As String = "CKOAREP"
    Public Const TBL���H�v��t�@�C�� As String = "CKODREP"
    Public Const TBL���H��ރt�@�C�� As String = "CKOBREP"
    Public Const TBL���H�ؒf�Ǘ��t�@�C�� As String = "CKOGREP"
    Public Const TBL���H���i�t�@�C�� As String = "CKOCREP"
    Public Const TBL���H���׌��i�t�@�C�� As String = "CKOLREP"
    Public Const TBL���H�����t�@�C�� As String = "CKOFREP"
    Public Const TBL���H�󒍕R�t�����t�@�C�� As String = "CKOHREP"

    Public Const TBL�o�ɗ\��t�@�C�� As String = "CKTDREP"

    Public Const TBL�󒍃t�@�C�� As String = "CKJAREP"
    Public Const TBL�󒍖��׃t�@�C�� As String = "CKJBREP"
    Public Const TBL�󒍎�z�t�@�C�� As String = "CKJCREP"

    Public Const TBL�݌Ƀt�@�C�� As String = "CKQBREP"
    Public Const TBL�݌ɖ��׃t�@�C�� As String = "CKQCREP"

    Public Const TBL��ޕt�я��t�@�C�� As String = "CKQDREP"

    Public Const TBL�@�B�}�X�^ As String = "MRMNREP"
    Public Const TBL�i���d�l�}�X�^ As String = "MRFCREP"

    Public Const TBL�N���[���t�@�C�� As String = "CKCLREP"
    Public Const TBL�N���[�����׃t�@�C�� As String = "CKCMREP"

    Public Const TBL��Ǝ��� As String = "CKFKREP"
    Public Const TBL�󕥃t�@�C�� As String = "CKVEREP"

    Public Const TBL�󒍗��� As String = "CKJDREP"

    ''�V�X�e��
    Public Const TBLS�v�����^��� As String = "MRSTREP"
    Public Const TBLS�敪�Ǘ��t�@�C�� As String = "MRSDREP"
    Public Const TBLS�ėp�敪�Ǘ��t�@�C�� As String = "MRKJREP"
    Public Const TBLS�r������t�@�C�� As String = "MRSGREP"

    ''�}�X�^
    Public Const TBLM�ėp�̔ԃ}�X�^ As String = "MRMWREP"
    Public Const TBLM�@�B�}�X�^ As String = "MRMNREP"
    Public Const TBLM�����}�X�^ As String = "MRMAREP"
    Public Const TBLM���[�J�}�X�^ As String = "MRMFREP"
    Public Const TBLM�i��`��}�X�^ As String = "MRMHREP"
    Public Const TBLM�K�i�|��}�X�^ As String = "MRMIREP"
    Public Const TBLM�d��}�X�^ As String = "MRHYREP"
    Public Const TBLM����}�X�^ As String = "MRUXREP"
    Public Const TBLM�g�D�}�X�^ As String = "MRMUREP"
    Public Const TBLM�S���҃}�X�^ As String = "MRMMREP"
    Public Const TBL���[�ݒ�t�@�C�� As String = "MRSSREP"
    Public Const TBLM���Ӑ�}�X�^�t�@�C�� As String = "MRMBREP"
    Public Const TBLM�����x�������}�X�^�t�@�C�� As String = "MRMEREP"
    Public Const TBLM�H������S���҃}�X�^�t�@�C�� As String = "MRKTREP"
    Public Const TBLM�ڕt�}�X�^�t�@�C�� As String = "MRMJREP"
    Public Const TBLM���[�J���Ў��ʃ}�X�^ As String = "MRKSREP"

    '���X�ǉ���
    Public Const TBL�d���t�@�C�� As String = "CKDAREP"
    Public Const TBL�d�����׃t�@�C�� As String = "CKDBREP"
    Public Const TBL����t�@�C�� As String = "CKEAREP"
    Public Const TBL���㖾�׃t�@�C�� As String = "CKEBREP"
    Public Const TBL���㖾�׌��i�t�@�C�� As String = "CKEIREP"
    Public Const TBL���{�����󒍃t�@�C�� As String = "CKJEREP"
    Public Const TBL���H�v�㖾�׃t�@�C�� As String = "CKOEREP"

#End Region

#Region "��`�萔"
    ''�t���O(����)
    Public Const STRFLGON As String = "1"
    Public Const STRFLGOFF As String = "0"
    ''�t���O(���l)
    Public Const INTFLGON As Integer = 1
    Public Const INTFLGOFF As Integer = 0

    Public Const TPID As String = "TPSYSTEM"   ''(���ю��W�V�X�e���X�������ύX�_�ꗗ No.14 �Ή�)

    ''�d�ʗe�ς̐��l
    Public Const FORMAT_����_����1 As String = "#,##0.0"
    Public Const FORMAT_����_����2 As String = "#,##0.00"
    Public Const FORMAT_����_����3 As String = "#,##0.000"
    Public Const FORMAT_���� As String = "#,##0"

    Public Const FORMAT_���t As String = "yyyy/MM/dd"
    Public Const FORMAT_���� As String = "yyyy/MM/dd HH:mm:ss"
    Public Const FORMAT_���� As String = "HH:mm"
    Public Const FORMAT_�����b As String = "HH:mm:ss"

    Public Const FORMAT_����14 As String = "yyyyMMddHHmmss"
   
    Public Const DL_�X���b�^���C�� As String = "S"

#End Region

#Region "�萔��`(�f�[�^��)"
    '���ʍ��� --------------------------------------------------

#End Region

#Region "�萔��`(�ŏ��l�E�ő�l)"

#End Region

#Region "�萔��`(MSG_)"
    Public Const MSG_������ As String = "�E�E�E���΂炭���҂����������B"
    Public Const MSG_������ As String = "������" & MConst.MSG_������
    Public Const MSG_�o�^�� As String = "�o�^��" & MConst.MSG_������
    Public Const MSG_�폜�� As String = "�폜��" & MConst.MSG_������
    Public Const MSG_���s�� As String = "���s��" & MConst.MSG_������
    Public Const MSG_���s�� As String = "���s��" & MConst.MSG_������

    Public Const MSG_�m�F As String = "��낵���ł����H"
    Public Const MSG_�o�^�m�F As String = "�f�[�^��o�^���܂��B" & MConst.MSG_�m�F
    Public Const MSG_�폜�m�F As String = "�I���f�[�^���폜���܂��B" & MConst.MSG_�m�F
    Public Const MSG_���s�m�F As String = "���������s���܂��B" & MConst.MSG_�m�F
    Public Const MSG_���s�m�F As String = "�𔭍s���܂��B" & MConst.MSG_�m�F

    Public Const MSG_�Y���f�[�^�Ȃ� As String = "�Y���f�[�^�͂���܂���B"
    Public Const MSG_�Y���f�[�^���� As String = "�Y���f�[�^������, #,##0���ł��B"

    Public Const MSG_�o�^�� As String = "���łɓo�^�ςł��B"
    Public Const MSG_�����I��s�� As String = "�f�[�^�������I������Ă��܂��B"
    Public Const MSG_�f�[�^���I�� As String = "�f�[�^��I�����ĉ������B"
    Public Const MSG_���w�� As String = "���w�肵�ĉ������B"
    Public Const MSG_�s�� As String = "�Ɍ�肪����܂��B"
    Public Const MSG_�͈͕s�� As String = "�͈̔͂Ɍ�肪����܂��B"

    Public Const MSG_LAN_ERR As String = "�̐ڑ��Ɏ��s���܂����B"
    Public Const MSG_COM_ERR As String = "��COM�I�[�v���Ɏ��s���܂����B"
    Public Const MSG_DAT_ERR As String = "�̃f�[�^�擾�Ɏ��s���܂����B"
    Public Const MSG_CHK_OK As String = "���ׂĂ̋@��͐���ɓ��삵�Ă��܂��B"
    Public Const MSG_SLD_NG As String = "�����f�[�^�������ɃG���[���������܂����B�@��`�F�b�N�ɂĂ��m�F�������B"

#End Region

#Region "�ҏW�ł̉�ʈړ����[�h"
  ''�ҏW�ł̉�ʈړ����[�h
    Public Enum gEnmMoveMode
        �i���ړ���
        �N���[���ړ���
        �ʏ�ړ� = -1
    End Enum

#End Region

#Region "�萔��`(���ID)"
    ''���C�����j���[
    Public Const ID_L000_���O�C���F�� As String = "L000"

    Public Const ID_0000_���C�����j���[ As String = "C0000"
    Public Const ID_G001_�o�b�`�J�n�I�� As String = "G001"
    Public Const ID_G002_���C���U�֍�Ǝw�� As String = "CG002"
    Public Const ID_G003_��ĕ�[���x�����s As String = "CG003"
    Public Const ID_G004_��ĕ�[���x�����s_�ڍ� As String = "CG004"
    Public Const ID_G005_���������N�� As String = "CG005"
    Public Const ID_S001_�o�b�`�i���Ɖ�_���C���� As String = "CS001"
    Public Const ID_S002_�o�b�`�i���Ɖ�_�Z���^�� As String = "CS002"
    Public Const ID_M001_��揤�i�����e�i���X As String = "CM001"
    Public Const ID_M002_����m�F As String = "CM002"

#End Region

#Region "�񋓌^��`"

    Public Enum gEnm�ڑ�
        ORACLE
        SQLServer
        ODBC
    End Enum

    ''��b�R�[�h�ɂ��Ȃ�(000�ɂ��߂�)
    Public Enum gEnm����b�R�[�h
        �Z�b�g�� = 1
        �Z�b�g���� = 2
        ��DS = 3
        ��C = 4
        ��WS = 5
        �������� = 6
        �Ίp��A = 7
        �Ίp��B = 8
        ������A = 9
        ������B = 10
    End Enum

    Public Enum gEnm�[��
        ���[�J�N�� = 1
        �Г��N�� = 2
        TB���X = 1
        �r = 2
        ���̑� = 3
    End Enum

#End Region

#Region "�F�錾"
    ''�O���b�h�̏ꍇ�A�X�^�C���̖��O�ƐF�ϐ��̃Z�b�g�Ő錾
    Public Const COLORNAME_�� As String = "��"
    Public COLOR_�� As Color = System.Drawing.Color.White

    Public Const COLORNAME_���F As String = "���F"
    Public COLOR_���F As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))

    Public Const COLORNAME_�I�����W As String = "�I�����W"
    Public COLOR_�I�����W As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))

    Public Const COLORNAME_�� As String = "��"
    Public COLOR_�� As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))

    Public Const COLORNAME_�� As String = "��"
    Public COLOR_�� As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))

    Public Const COLORNAME_�� As String = "��"
    Public COLOR_�� As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))

    ''UsrLabl�̐F
    Public COLOR_���x��_�ʏ� As Color = System.Drawing.SystemColors.HighlightText
    Public COLOR_���x��_�I�� As Color = System.Drawing.Color.SkyBlue

    ''�_�C�A���O�̘g�̐F
    Public COLOR_�_�C�A���O�g_�ʏ� As Color = System.Drawing.SystemColors.Control
    Public COLOR_�_�C�A���O�g_�I�� As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))

#End Region


End Module
