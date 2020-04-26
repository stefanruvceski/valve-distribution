object PSForm: TPSForm
  Left = 277
  Top = 84
  BorderStyle = bsDialog
  Caption = 'Project from files'
  ClientHeight = 386
  ClientWidth = 537
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesigned
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    Left = 0
    Top = 50
    Width = 537
    Height = 2
    Align = alTop
    Shape = bsTopLine
    ExplicitTop = 53
  end
  object Bevel2: TBevel
    Left = 0
    Top = 341
    Width = 537
    Height = 2
    Align = alBottom
    Shape = bsBottomLine
    ExplicitTop = 329
  end
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 537
    Height = 50
    Align = alTop
    BevelOuter = bvNone
    Color = clWhite
    ParentBackground = False
    TabOrder = 2
    object lbPage: TLabel
      Left = 16
      Top = 8
      Width = 32
      Height = 13
      Caption = 'lbPage'
    end
    object Image1: TImage
      Left = 487
      Top = 0
      Width = 50
      Height = 50
      Align = alRight
      Center = True
      Picture.Data = {
        0954506E67496D61676589504E470D0A1A0A0000000D49484452000000180000
        00180806000000E0773DF80000032E4944415478DACD956B4853611CC6FFDB74
        2969255276B3123F4509690C27CA76CC482D6566E626DE482D492248DDD6C999
        5331265ED3441C0A696EA4E8188B14A9E699762148CB91E652B2F2325BC19C99
        73383D9D130A7D48D235A1070E2FEFF9F0FC78FECF39EF4BC1719C029B28CA7F
        01E84590F3336F9E153B1F0BCC3F89618D36035ED36915CBAE8E410E3ECC3B07
        C462B91B822C12E65C1ABC6F3A9CE9EBA8E474DCBB80E3C93601BE6318659477
        5A7BB4A7EAC854432B8CD475BF9B35595B3D823CD00055157D42510D9D694F6F
        A4E3B8C4E604030892EECE72ADDD5F2087C5CF6AD03797C3BE4B5780B6C30CDA
        EBF96076490CF5178B1FD90C3062D896FEE85343EC419597C3EE40007C0CC0AA
        23D61780C536C2B4C92739402C6E3E8820B8CD252B28947C467148AE67763961
        3E443C6F01965E81F9C304F4954E426FDB4CDF4E7FF6CD340CEBDC3080283496
        6A1D6E622AABE8B46DC46BEB0061DE0FB0680098A7032C38C3DC9009D4D5C3F0
        F2F18F6B45387E7BDD00F253A4C148335359E9487531032C13E69641C2FC1B2C
        1970F8F2DC08D3DA7930E82C30F171CE021E8197891477D70D78E04ED7B39A43
        3D660DB3601A9E04E3C80CF8E7EF01FA765798EC9C825BE83C448B72A155A978
        C84590A413E23CE38646F404412E8E6B34EC05009D6F5E5EDF1886791EF2D6D6
        32515F18A81E84B86A033092924094930332B9BC2C32325270DCCFEFAF65AFF9
        277FC230DAFD33C1FD57DB183EDD953A2819706ED7180CE7E2E3E34124124146
        4646854422C9663018B84D0052F5087276EFD6BEF6A951B3C53B4EB4AB4EA7E3
        B7B6B48892882442A110A452692997CB1532994CDC260031264A7D7070B6179B
        FD75B5D09898982285428192495014051E8F57A1D56AB36C02ACA5A8A8A80295
        4A254A4C4CFC9584C3E19435343408582C166E1700A9888888A28E8E0E342121
        01040201848787978D8F8FF3ED062015161656D8D5D5954326E1F3F9E4BE4226
        936523BF1D25FF7CE184848414A8D5EA5FC56766664229A1D4D454E12AC42E37
        1A6156A4D16850324956561699A444AFD70BED0658811412909C949414707272
        32D5D4D4B8D915B00211F7F4F4A453A954A9D56ACDB33BE04FDA74C04FE1969E
        F8297701330000000049454E44AE426082}
      ExplicitLeft = 484
    end
    object lbPageInfo: TLabel
      Left = 28
      Top = 26
      Width = 52
      Height = 13
      Caption = 'lbPageInfo'
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 343
    Width = 537
    Height = 43
    Align = alBottom
    BevelOuter = bvNone
    ParentBackground = False
    ParentColor = True
    TabOrder = 1
    object sbNext: TButton
      Left = 368
      Top = 8
      Width = 75
      Height = 25
      Caption = 'Next >'
      Default = True
      TabOrder = 1
    end
    object sbClose: TButton
      Left = 452
      Top = 8
      Width = 75
      Height = 25
      Caption = 'Close'
      ModalResult = 2
      TabOrder = 2
    end
    object sbBack: TButton
      Left = 292
      Top = 8
      Width = 75
      Height = 25
      Cancel = True
      Caption = '< Back'
      TabOrder = 0
    end
  end
  object pcWizard: TPageControl
    AlignWithMargins = True
    Left = 32
    Top = 64
    Width = 473
    Height = 265
    Margins.Left = 32
    Margins.Top = 12
    Margins.Right = 32
    Margins.Bottom = 12
    ActivePage = tsHHP
    Align = alClient
    Style = tsButtons
    TabOrder = 0
    object tsOptions: TTabSheet
      Hint = 
        'Select the folder with your files, check additional options and ' +
        'click Next'
      Caption = 'Create a new help project from an existing files'
      ExplicitLeft = 0
      ExplicitTop = 0
      ExplicitWidth = 0
      ExplicitHeight = 0
      DesignSize = (
        465
        234)
      object lbFolder: TLabel
        Left = 0
        Top = 0
        Width = 105
        Height = 13
        Caption = 'Folder with topic files:'
      end
      object lbProject: TLabel
        Left = 0
        Top = 48
        Width = 108
        Height = 13
        Caption = 'New project file name:'
      end
      object Label4: TLabel
        Left = 101
        Top = 90
        Width = 335
        Height = 13
        Alignment = taRightJustify
        Anchors = [akTop, akRight]
        Caption = 
          'Information: Project must be located in the topic files folder o' +
          'r above.'
      end
      object Label5: TLabel
        Left = 0
        Top = 124
        Width = 217
        Height = 13
        Caption = 'Topic file extensions (separated by commas):'
      end
      object edFolder: TEdit
        Left = 0
        Top = 16
        Width = 437
        Height = 21
        Anchors = [akLeft, akTop, akRight]
        TabOrder = 0
      end
      object sbFolder: TButton
        Left = 440
        Top = 16
        Width = 23
        Height = 21
        Anchors = [akTop, akRight]
        Caption = '...'
        TabOrder = 1
      end
      object edProject: TEdit
        Left = 0
        Top = 64
        Width = 437
        Height = 21
        Anchors = [akLeft, akTop, akRight]
        TabOrder = 2
      end
      object sbProject: TButton
        Left = 440
        Top = 64
        Width = 23
        Height = 21
        Anchors = [akTop, akRight]
        Caption = '...'
        TabOrder = 3
      end
      object edExt: TEdit
        Left = 0
        Top = 140
        Width = 461
        Height = 21
        Anchors = [akLeft, akTop, akRight]
        TabOrder = 4
        Text = 'htm, html'
      end
    end
    object tsProgress: TTabSheet
      Hint = 'creating a new project ...'
      Caption = 'Please wait,'
      ExplicitLeft = 0
      ExplicitTop = 0
      ExplicitWidth = 0
      ExplicitHeight = 0
      object Label1: TLabel
        Left = 0
        Top = 16
        Width = 35
        Height = 13
        Caption = 'Status:'
      end
      object lbStatus: TLabel
        Left = 0
        Top = 36
        Width = 17
        Height = 13
        Caption = '0%'
      end
    end
    object tsFinished: TTabSheet
      Hint = 'Click Finish to exit the wizard'
      Caption = 'Finish the wizard'
      ExplicitLeft = 0
      ExplicitTop = 0
      ExplicitWidth = 0
      ExplicitHeight = 0
      object Label2: TLabel
        AlignWithMargins = True
        Left = 0
        Top = 0
        Width = 367
        Height = 13
        Margins.Left = 0
        Margins.Top = 0
        Margins.Right = 0
        Margins.Bottom = 4
        Align = alTop
        Caption = 
          'Wizard has finished the creation of a new project. See the repor' +
          't log bellow.'
      end
      object mReport: TMemo
        Left = 0
        Top = 17
        Width = 465
        Height = 217
        Align = alClient
        ParentColor = True
        ReadOnly = True
        ScrollBars = ssVertical
        TabOrder = 0
        WantReturns = False
        WordWrap = False
      end
    end
    object tsHHP: TTabSheet
      Caption = 'tsHHP'
      object mHHPTemplate: TMemo
        Left = 0
        Top = 0
        Width = 457
        Height = 129
        Lines.Strings = (
          '[OPTIONS]'
          'Title='
          'Compiled file='
          'Error log file='
          'Default topic='
          'Language=0x0409 English (United States)'
          'Full text search stop list file='
          'Contents file=Contents.hhc'
          'Index file=Index.hhk'
          'Binary TOC=No'
          'Auto index=No'
          'Binary Index=Yes'
          'Create CHI file=No'
          'Full-text search=Yes'
          'Display compile progress=Yes'
          'Display compile notes=Yes'
          'Default window=main'
          'Enhanced decompilation=Yes'
          'Flat=No'
          'Compatibility=1.1 or later'
          'Default Font=Tahoma,8,1'
          ''
          '[WINDOWS]'
          
            'main="","$HHC","$HHK","$DEF","$DEF",,,,,0x00063520,264,0x0010304' +
            'E,[25,25,756,515],,,,0,0,0,0')
        TabOrder = 0
        WantReturns = False
        WordWrap = False
      end
      object mHHCTemplate: TMemo
        Left = 0
        Top = 136
        Width = 209
        Height = 97
        Lines.Strings = (
          '<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">'
          '<HTML>'
          '<HEAD>'
          '<meta name="GENERATOR" content="Precision Helper">'
          '<!-- Sitemap 1.0 -->'
          '</HEAD>'
          '<BODY>'
          '    <OBJECT type="text/site properties">'
          '      <param name="FrameName" value="right">'
          '      <param name="Window Styles" value="0x00800025">'
          '      <param name="comment" value="title:">'
          '      <param name="comment" value="base:">'
          '    </OBJECT>'
          '    <UL>$TOC'
          '   </UL>'
          '</BODY>'
          '</HTML>')
        TabOrder = 1
        WantReturns = False
        WordWrap = False
      end
      object mHHKTemplate: TMemo
        Left = 216
        Top = 136
        Width = 209
        Height = 97
        Lines.Strings = (
          '<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">'
          '<HTML>'
          '<HEAD>'
          '<meta name="GENERATOR" content="Precision Helper">'
          '<!-- Sitemap 1.0 -->'
          '</HEAD>'
          '<BODY>'
          '    <OBJECT type="text/site properties">'
          '      <param name="FrameName" value="right">'
          '    </OBJECT>'
          '    <UL>$IDX'
          '   </UL>'
          '</BODY>'
          '</HTML>')
        TabOrder = 2
        WantReturns = False
        WordWrap = False
      end
    end
  end
end
