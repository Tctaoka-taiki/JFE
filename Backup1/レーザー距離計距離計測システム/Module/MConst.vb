'*******************************************************************************
' @(h)  MConst.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  グローバル定数
'*******************************************************************************
Imports System.Drawing

Public Module MConst

#Region "テーブル"
    ''データファイル
    Public Const TBL加工ファイル As String = "CKOAREP"
    Public Const TBL加工計上ファイル As String = "CKODREP"
    Public Const TBL加工母材ファイル As String = "CKOBREP"
    Public Const TBL加工切断管理ファイル As String = "CKOGREP"
    Public Const TBL加工製品ファイル As String = "CKOCREP"
    Public Const TBL加工明細現品ファイル As String = "CKOLREP"
    Public Const TBL加工順序ファイル As String = "CKOFREP"
    Public Const TBL加工受注紐付解除ファイル As String = "CKOHREP"

    Public Const TBL出庫予定ファイル As String = "CKTDREP"

    Public Const TBL受注ファイル As String = "CKJAREP"
    Public Const TBL受注明細ファイル As String = "CKJBREP"
    Public Const TBL受注手配ファイル As String = "CKJCREP"

    Public Const TBL在庫ファイル As String = "CKQBREP"
    Public Const TBL在庫明細ファイル As String = "CKQCREP"

    Public Const TBL母材付帯情報ファイル As String = "CKQDREP"

    Public Const TBL機械マスタ As String = "MRMNREP"
    Public Const TBL品質仕様マスタ As String = "MRFCREP"

    Public Const TBLクレームファイル As String = "CKCLREP"
    Public Const TBLクレーム明細ファイル As String = "CKCMREP"

    Public Const TBL作業実績 As String = "CKFKREP"
    Public Const TBL受払ファイル As String = "CKVEREP"

    Public Const TBL受注履歴 As String = "CKJDREP"

    ''システム
    Public Const TBLSプリンタ情報 As String = "MRSTREP"
    Public Const TBLS区分管理ファイル As String = "MRSDREP"
    Public Const TBLS汎用区分管理ファイル As String = "MRKJREP"
    Public Const TBLS排他制御ファイル As String = "MRSGREP"

    ''マスタ
    Public Const TBLM汎用採番マスタ As String = "MRMWREP"
    Public Const TBLM機械マスタ As String = "MRMNREP"
    Public Const TBLM取引先マスタ As String = "MRMAREP"
    Public Const TBLMメーカマスタ As String = "MRMFREP"
    Public Const TBLM品種形状マスタ As String = "MRMHREP"
    Public Const TBLM規格鋼種マスタ As String = "MRMIREP"
    Public Const TBLM仕上マスタ As String = "MRHYREP"
    Public Const TBLM梱包マスタ As String = "MRUXREP"
    Public Const TBLM組織マスタ As String = "MRMUREP"
    Public Const TBLM担当者マスタ As String = "MRMMREP"
    Public Const TBL帳票設定ファイル As String = "MRSSREP"
    Public Const TBLM得意先マスタファイル As String = "MRMBREP"
    Public Const TBLM請求支払条件マスタファイル As String = "MRMEREP"
    Public Const TBLM工程現場担当者マスタファイル As String = "MRKTREP"
    Public Const TBLM目付マスタファイル As String = "MRMJREP"
    Public Const TBLMメーカ商社識別マスタ As String = "MRKSREP"

    '金森追加分
    Public Const TBL仕入ファイル As String = "CKDAREP"
    Public Const TBL仕入明細ファイル As String = "CKDBREP"
    Public Const TBL売上ファイル As String = "CKEAREP"
    Public Const TBL売上明細ファイル As String = "CKEBREP"
    Public Const TBL売上明細現品ファイル As String = "CKEIREP"
    Public Const TBL日本金属受注ファイル As String = "CKJEREP"
    Public Const TBL加工計上明細ファイル As String = "CKOEREP"

#End Region

#Region "定義定数"
    ''フラグ(文字)
    Public Const STRFLGON As String = "1"
    Public Const STRFLGOFF As String = "0"
    ''フラグ(数値)
    Public Const INTFLGON As Integer = 1
    Public Const INTFLGOFF As Integer = 0

    Public Const TPID As String = "TPSYSTEM"   ''(実績収集システムスリム化変更点一覧 No.14 対応)

    ''重量容積の数値
    Public Const FORMAT_数量_小数1 As String = "#,##0.0"
    Public Const FORMAT_数量_小数2 As String = "#,##0.00"
    Public Const FORMAT_数量_小数3 As String = "#,##0.000"
    Public Const FORMAT_整数 As String = "#,##0"

    Public Const FORMAT_日付 As String = "yyyy/MM/dd"
    Public Const FORMAT_日時 As String = "yyyy/MM/dd HH:mm:ss"
    Public Const FORMAT_時分 As String = "HH:mm"
    Public Const FORMAT_時分秒 As String = "HH:mm:ss"

    Public Const FORMAT_日時14 As String = "yyyyMMddHHmmss"
   
    Public Const DL_スリッタライン As String = "S"

#End Region

#Region "定数定義(データ長)"
    '共通項目 --------------------------------------------------

#End Region

#Region "定数定義(最小値・最大値)"

#End Region

#Region "定数定義(MSG_)"
    Public Const MSG_処理中 As String = "・・・しばらくお待ちください。"
    Public Const MSG_検索中 As String = "検索中" & MConst.MSG_処理中
    Public Const MSG_登録中 As String = "登録中" & MConst.MSG_処理中
    Public Const MSG_削除中 As String = "削除中" & MConst.MSG_処理中
    Public Const MSG_実行中 As String = "実行中" & MConst.MSG_処理中
    Public Const MSG_発行中 As String = "発行中" & MConst.MSG_処理中

    Public Const MSG_確認 As String = "よろしいですか？"
    Public Const MSG_登録確認 As String = "データを登録します。" & MConst.MSG_確認
    Public Const MSG_削除確認 As String = "選択データを削除します。" & MConst.MSG_確認
    Public Const MSG_実行確認 As String = "処理を実行します。" & MConst.MSG_確認
    Public Const MSG_発行確認 As String = "を発行します。" & MConst.MSG_確認

    Public Const MSG_該当データなし As String = "該当データはありません。"
    Public Const MSG_該当データ件数 As String = "該当データ件数は, #,##0件です。"

    Public Const MSG_登録済 As String = "すでに登録済です。"
    Public Const MSG_複数選択不可 As String = "データが複数選択されています。"
    Public Const MSG_データ未選択 As String = "データを選択して下さい。"
    Public Const MSG_未指定 As String = "を指定して下さい。"
    Public Const MSG_不正 As String = "に誤りがあります。"
    Public Const MSG_範囲不正 As String = "の範囲に誤りがあります。"

    Public Const MSG_LAN_ERR As String = "の接続に失敗しました。"
    Public Const MSG_COM_ERR As String = "のCOMオープンに失敗しました。"
    Public Const MSG_DAT_ERR As String = "のデータ取得に失敗しました。"
    Public Const MSG_CHK_OK As String = "すべての機器は正常に動作しています。"
    Public Const MSG_SLD_NG As String = "距離データ処理中にエラーが発生しました。機器チェックにてご確認下さい。"

#End Region

#Region "編集での画面移動モード"
  ''編集での画面移動モード
    Public Enum gEnmMoveMode
        品質移動無
        クレーム移動無
        通常移動 = -1
    End Enum

#End Region

#Region "定数定義(画面ID)"
    ''メインメニュー
    Public Const ID_L000_ログイン認証 As String = "L000"

    Public Const ID_0000_メインメニュー As String = "C0000"
    Public Const ID_G001_バッチ開始終了 As String = "G001"
    Public Const ID_G002_ライン振替作業指示 As String = "CG002"
    Public Const ID_G003_一斉補充ラベル発行 As String = "CG003"
    Public Const ID_G004_一斉補充ラベル発行_詳細 As String = "CG004"
    Public Const ID_G005_日次処理起動 As String = "CG005"
    Public Const ID_S001_バッチ進捗照会_ライン別 As String = "CS001"
    Public Const ID_S002_バッチ進捗照会_センタ別 As String = "CS002"
    Public Const ID_M001_企画商品メンテナンス As String = "CM001"
    Public Const ID_M002_基準情報確認 As String = "CM002"

#End Region

#Region "列挙型定義"

    Public Enum gEnm接続
        ORACLE
        SQLServer
        ODBC
    End Enum

    ''基礎コードにもなる(000にうめる)
    Public Enum gEnm板厚基礎コード
        セット幅 = 1
        セット長さ = 2
        板厚DS = 3
        板厚C = 4
        板厚WS = 5
        実測長さ = 6
        対角線A = 7
        対角線B = 8
        実測幅A = 9
        実測幅B = 10
    End Enum

    Public Enum gEnm端板
        メーカ起因 = 1
        社内起因 = 2
        TBロス = 1
        疵 = 2
        その他 = 3
    End Enum

#End Region

#Region "色宣言"
    ''グリッドの場合、スタイルの名前と色変数のセットで宣言
    Public Const COLORNAME_白 As String = "白"
    Public COLOR_白 As Color = System.Drawing.Color.White

    Public Const COLORNAME_黄色 As String = "黄色"
    Public COLOR_黄色 As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))

    Public Const COLORNAME_オレンジ As String = "オレンジ"
    Public COLOR_オレンジ As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))

    Public Const COLORNAME_赤 As String = "赤"
    Public COLOR_赤 As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))

    Public Const COLORNAME_青 As String = "青"
    Public COLOR_青 As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))

    Public Const COLORNAME_緑 As String = "緑"
    Public COLOR_緑 As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))

    ''UsrLablの色
    Public COLOR_ラベル_通常 As Color = System.Drawing.SystemColors.HighlightText
    Public COLOR_ラベル_選択中 As Color = System.Drawing.Color.SkyBlue

    ''ダイアログの枠の色
    Public COLOR_ダイアログ枠_通常 As Color = System.Drawing.SystemColors.Control
    Public COLOR_ダイアログ枠_選択中 As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))

#End Region


End Module
