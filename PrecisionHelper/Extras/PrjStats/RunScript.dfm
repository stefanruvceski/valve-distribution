object PSForm: TPSForm
  Left = 620
  Top = 324
  BorderIcons = [biSystemMenu]
  BorderStyle = bsSingle
  Caption = 'Project statistics'
  ClientHeight = 219
  ClientWidth = 378
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesigned
  DesignSize = (
    378
    219)
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    AlignWithMargins = True
    Left = 8
    Top = 8
    Width = 362
    Height = 167
    Margins.Left = 8
    Margins.Top = 8
    Margins.Right = 8
    Margins.Bottom = 44
    Align = alClient
    Shape = bsFrame
    ExplicitWidth = 409
    ExplicitHeight = 194
  end
  object lbTitle: TLabel
    Left = 16
    Top = 16
    Width = 28
    Height = 13
    Caption = 'lbTitle'
  end
  object lbFile: TLabel
    Left = 16
    Top = 36
    Width = 343
    Height = 13
    Anchors = [akLeft, akTop, akRight]
    AutoSize = False
    Caption = 'lbFile'
    EllipsisPosition = epPathEllipsis
    ParentShowHint = False
    ShowHint = True
    ExplicitWidth = 416
  end
  object lbTopicsCap: TLabel
    Left = 16
    Top = 72
    Width = 69
    Height = 13
    Caption = 'Topics in TOC:'
  end
  object lbTopics: TLabel
    Left = 112
    Top = 72
    Width = 38
    Height = 13
    Caption = 'lbTopics'
  end
  object Bevel2: TBevel
    Left = 16
    Top = 60
    Width = 345
    Height = 6
    Anchors = [akLeft, akTop, akRight]
    Shape = bsTopLine
    ExplicitWidth = 418
  end
  object lbIndex: TLabel
    Left = 112
    Top = 92
    Width = 36
    Height = 13
    Caption = 'lbIndex'
  end
  object lbIndexCap: TLabel
    Left = 16
    Top = 92
    Width = 81
    Height = 13
    Caption = 'Index keywords:'
  end
  object lbContextCap: TLabel
    Left = 16
    Top = 112
    Width = 62
    Height = 13
    Caption = 'Context IDs:'
  end
  object lbContext: TLabel
    Left = 112
    Top = 112
    Width = 47
    Height = 13
    Caption = 'lbContext'
  end
  object lbIncludedCap: TLabel
    Left = 16
    Top = 132
    Width = 67
    Height = 13
    Caption = 'Included files:'
  end
  object lbIncluded: TLabel
    Left = 112
    Top = 132
    Width = 49
    Height = 13
    Caption = 'lbIncluded'
  end
  object lbMergedCap: TLabel
    Left = 16
    Top = 152
    Width = 62
    Height = 13
    Caption = 'Merged files:'
  end
  object lbMerged: TLabel
    Left = 112
    Top = 152
    Width = 44
    Height = 13
    Caption = 'lbMerged'
  end
  object lbLastUpdCap: TLabel
    Left = 184
    Top = 72
    Width = 61
    Height = 13
    Caption = 'Last update:'
  end
  object lbLastUpdate: TLabel
    Left = 260
    Top = 72
    Width = 63
    Height = 13
    Caption = 'lbLastUpdate'
  end
  object sbOK: TButton
    Left = 215
    Top = 184
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = 'OK'
    Default = True
    ModalResult = 1
    TabOrder = 0
  end
  object sbCancel: TButton
    Left = 295
    Top = 184
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Cancel = True
    Caption = 'Cancel'
    ModalResult = 2
    TabOrder = 1
  end
end
