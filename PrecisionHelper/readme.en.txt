Precision Helper 2.0
====================

Precision Helper is a tool for creating and managing help projects
in Microsoft Compiled HTML Help (CHM) format.

It focuses on the organization of existing html files, xml files,
scripts, images and other resources so that the help author has
the best overview of its project.

Precision Helper works natively with the Microsoft HTML Help projects format (HHP)
and allows to publish resulting help to the CHM, WebHelp, ePUB (e-book), PDF
and the "single doc" formats.

Precision Helper is designed for advanced developers and authors, but user-friendly
environment enables creating help projects also by novice users.

Precision Helper is distributed as a FREEWARE. Read License.txt for more infomations.


What's new?
-----------
- Embedded editor of topics
- Support for application extensions (Add-Ons)
- Topic and project templates


System requirements:
--------------------
Hardware:
  IBM compatible PC
  256 MB RAM
   25 MB free disk space

Operating system:
  Microsoft Windows 2000/XP/Vista/7

Others:
  Microsoft HtmlHelp Workshop (for compiling CHM files)
  Microsoft Internet Explorer 6.0+ (for previewing of topics)


Installation:
-------------
Run installer and follow the setup wizard instructions. On Windows Vista you must
allow user rights elevation to administrative rights during installation.

A portable version can be simply unpacked into desired folder and used by executing
the PrecisionHelper.exe file.

Note:
  Microsoft Html Help Workshop must be installed to properly compile resulting help.
  In fact, only a few dll files from this product are needed, but Microsoft does not
  recommend to install and register them outside of it's product.
  The setup wizard will automatically ask you for download and install Microsoft
  Html Help Workshop if it is not presented on your system.


Change log:
-----------
- v2.0 (2011-04-27)
  * added:    Embedded editor of topics, including the syntax highlighting, code completion, text and code insertion via predefined keystrokes, and including the support for using extensions/add-ons (see bellow).
              All these features are customizable by defining and selecting your own syntax schemes.
  * added:    Topic templates. Any topic can be saved and used as a template (including an automatic detection of used styles, images, scripts, etc.)
  * added:    Project templates. Any project, including the topics, images, and other files, can be defined and used as a template.
  * added:    Application extensions (Add-Ons). Precision Helper can be extended by user defined add-ons. A command-line and Pascal Script interfaces (including the GUI) are supported.
  * added:    The first extensions are available, such as HTML Tidy, Project statistics, Edit TOC and Index in an external editor, Wizard to create a new project from existing topic files, and more.
  * added:    Now build lists can contain also other formats of compilation (export), such as WebHelp, SingleHTML, etc.
  * added:    Option to automatically add all used files into an "Included files list" (on project save)
  * added:    WebHelp templates, that consist of navigation frames, now contain the ability to directly navigate to desired topic.
              So you can refer to a topic in this kind of help format, by using the simple url syntax like "c:\WebHelp\index.htm#mytopic.htm" or "http://www.mysite.com/WebHelp/index.php#mytopic.htm", etc.
  * added:    Auto refresh of topic preview when editing in an external editor (after the user switches back to Precision Helper)
  * added:    Function for exploring the folder of selected file (in Files/Projects/Builds lists) now supports customizable file manager option
  * added:    Edit button for referenced TOC (in topic page window)
  * added:    New GUI color schemes (Windows 7, Office 2010, etc.)
  * added:    "ExtraSeparators" template for WebHelp export (to support languages like Chinese, Japanese, etc.)
  * added:    "New window" button for opening a new instance of Precision Helper (in main menu)
  * improved: Last selected templates and targets for export (publishing) are now retained for each project apart
  * improved: WebHelp format now supports topic titles that include apostrophes
  * improved: WebHelp search feature has been improved, so the whole online help can work as embedded into an IFRAME now
  * improved: WebHelp search feature now supports words (expressions) with apostrophes
  * improved: Correct handling of files stored in UTF8 encoding, without preamble. The problems were noticeable especially when exporting into WebHelp.
              Precision Helper now supports both these forms of UTF8 files (whether it is a configuration file, template file, topic, etc.).
  * improved: Bookmarks (internal links) inside the SingleHTML help are defined now as &lt;A name="#..."&gt;&lt;/A&gt;
              (without the end tag, the links have been displayed incorrectly in some browsers, eg Firefox and Opera)
  * improved: In project file selection dialog now you can switch between available places by pressing the Alt+Up or Alt+Down hot-keys
  * fixed:    AutoSync feature in a WebHelp has been fixed for use in Internet Explorer, where the addresses encoded in MIME/URL did not work
  * fixed:    AutoSync feature in a WebHelp now correctly navigates to topics with the same names, but located in other branches of TOC
  * fixed:    Application modal dialogs have been dedicated to show strictly in the current desktop (to support dual monitors usage)
  * fixed:    Error on adding the first keyword for topic (in the quick add keyword panel), that appears in some specific situations (eg when the index of keywords was empty)
  * fixed:    If you have cleared all the context help IDs, Precision Helper did not clear an appropriate sections (MAP and ALIAS)
              in the project file. This has been fixed.

- v1.1 (1.7.2010)
  * added:    Publishing to the ePUB (e-book) format
  * improved: Significantly improved export to the WebHelp format (including the Search option)
  * added:    French translation (officially) added
  * fixed:    Topics that was defined as a local links (ie. "default.htm#section1") were not displayed in a topic preview
              (this behaviour is supported now, but generally we do not recommend to use this kind of links in TOC and INDEX)

- v1.0.4.10 (12.3.2010)
  * added:    Russian translation
  * improved: a few buttons and panels were enlarged to fit the non-english localization texts
  * added:    a multimedia files extensions was added to the select files dialog, to support inclusion of *.mp3, *.wav, *.avi, *.wmv, *.mpg, *.mpeg and *.swf files

- v1.0.3.28 (18.11.2009)
  * added:    Polish translation
  * added:    Hungarian translation
  * improved: a few buttons and panels were enlarged to fit the non-english localization texts
  * added:    button for quick hiding of Properties bar
  * added:    option to open the folder of selected file in Windows Explorer (for Included files, Projects list and Builds list)
  * improved: horizontal scroll bar in log file panel is now visible when needed
  * improved: the option 'Save contents and index items as html encoded' was added to the 'Project defaults' tab of Options dialog
  * fixed:    html encoded items are now displayed correctly in 'Table of contents' and 'Index of keywords' (ie. "Read & Blue" instead of "Read &amp; Blue")
  * improved: CHM Import - links to topics in decompiled project (including TOC and INDEX) now contain 'backslashes', according to the topics listed in the 'FILES' section.
              (before this improvement, the links were decompiled as they were stored in the CHM, with the possible unwanted difference between TOC/INDEX and the FILES section)
  * fixed:    CHM Import - context IDs are now recovered also for the situation when the IDs were stored in the project file (.hhp)
  * improved: the option 'Open last project at startup' now works also when starting the application with the /N parameter
  * fixed:    a few minor fixes in english help (links, texts)
  * fixed:    'Text size' button (in ribbon bar) localization now works
  * fixed:    color scheme for 'Options->External tools' tab now works

- v1.0.2.16 (23.08.2009)
  * improved: better handling for one instance checking - the already running instance is set to the front correctly
  * added:    The VirtualTreeview.chm help file was included into the Samples folder, to show the decompiling possibilities on the independent project.
              Note: the decompiled help project cannot be compiled with hhc.exe compiler with unchecked "Show compilation progress" option on some machines (use the default hha.dll compiler instead).
                    When you check the mentioned option, everything works well also for hhc.exe compiler.
              Many thanks to VirtualTreeview component author for cooperation (Mike Lischke, Soft-Gems, see credits).
  * fixed:    "CHM Viewer" and "Select project file" dialog issue for the floppy drives (when A: or B: drives was installed but had no media inside)
  * fixed:    About box scaling on Windows XP when running under the Virtual PC (the window has larger size than the image)
  * fixed:    when dragging a new files (topics) from other application into the TOC, a topic name was not assigned (the copy and paste method worked well)

- version 1.0.1 (22.07.2009) is a first publicly released version


Used third-party components and libraries:
------------------------------------------
- CodeGear Delphi 2009 for Win32 Professional, http://www.embarcadero.com/
- TMS Component Pack Professional, http://www.tmssoftware.com
- VirtualTree, http://www.soft-gems.net
- Precision Language Suite for VCL, http://www.be-precision.com
- Precision VCL, http://www.be-precision.com
- Delphi HH Kit (IStorage implementation only), http://helpware.net/delphi/index.html
- PNG Components, http://www.thany.org
- NotifyIcon, http://www.torry.net/pages.php?id=245
- HyperParse, http://www.wakproductions.com/
- ExtLib, http://cc.embarcadero.com/Item/18586
- RemObjects PascalScript, http://www.remobjects.com/ps.aspx
- Unicode SynEdit, http://mh-nexus.de/en/unisynedit.php
- Microsoft Internet Explorer (IWebBrowser, mshtml.dll, ...), http://www.microsoft.com
- Microsoft Html Help Workshop (hha.dll, hhc.exe, ...), http://www.microsoft.com
- chmdeco, http://pabs.zip.to
- HTML Tidy Library Project, http://tidy.sourceforge.net/
- dTree script, http://www.destroydrop.com/
- KeyWorks Software and Work Write (hhc.exe error message ref.), http://www.keyworks.net, http://www.workwrite.com
- InnoSetup, http://www.jrsoftware.org
- ISTool, http://www.istool.org/
- IcoFX, http://icofx.ro/
- Rumshot, http://www.shellscape.org/rumshot/
- Fugue Small Icons, http://www.pinvoke.com/
- Silk Icons, http://www.famfamfam.com/lab/icons/silk/
- Developers Icons, http://sekkyumu.deviantart.com/art/Developpers-Icons-63052312
- Human O2 Icons, http://schollidesign.deviantart.com/art/Human-O2-Iconset-105344123
- Oxygen Icons, http://www.oxygen-icons.org/


Contact:
--------
Precision software & consulting
e-mail:  info@be-precision.com
www:     http://www.be-precision.com
support: www.be-precision.com/support
         support@be-precision.com
forum:   www.be-precision.com/forum
rss:     www.be-precision.com/rss_en.xml


========================================================
Copyright (c) 2008-2011  Precision software & consulting
All rights reserved.
