Precision Helper 2.0
====================

Precision Helper je nástrojem pro vytváøení a správu projektù nápovìdy
ve formátu Microsoft Compiled Html Help (CHM).

Je zamìøen na organizaci existujících html souborù, xml souborù,
skriptù, obrázkù a dalších zdrojù tak, aby mìl autor o svém projektu
co nejlepší pøehled.

Precision Helper pracuje nativnì s formátem projektù Microsoft Html Help (HHP)
a umožòuje publikovat výslednou nápovìdu do formátù CHM, WebHelp, ePUB (e-book) a PDF.

Precision Helper je urèen pro pokroèilé autory a vývojáøe, ale uživatelsky pøíjemné
prostøedí umožòuje vytváøet nápovìdy i zaèínajícím autorùm.

Precision Helper je distribuován jako FREEWARE. Více informací naleznete v souboru License.txt.


Novinky:
--------
- Vestavìný editor témat
- Podpora aplikaèních doplòkù
- Šablony témat a projektù


Systémové požadavky:
--------------------
Hardware:
  IBM-kompatibilní PC
  256 MB RAM
   25 MB volného místa na disku

Operaèní systém:
  Microsoft Windows 2000/XP/Vista/7

Ostatní:
  Microsoft HtmlHelp Workshop (pro kompilaci CHM souborù)
  Microsoft Internet Explorer 6.0+ (pro náhledy na témata)


Instalace:
----------
Spuste instalátor a postupujte dle pokynù prùvodce. Na Windows Vista
musíte bìheme instalace povolit zvýšení pøístupových práv na administrátorská.

Pøenosná verze mùže být jednoduše rozbalena do požadované složky a spuštìna
souborem PrecisionHelper.exe.

Poznámka:
  Microsoft Html Help Workshop musí být nainstalován pro správnou kompilaci
  výsledné nápovìdy. Ve skuteènosti jsou potøeba jen nìkteré knihovny tohoto
  produktu, ale spoleènost Microsoft nedoporuèuje jejich instalaci a registraci
  mimo svùj produkt.
  Prùvodce instalací se Vás automaticky dotáže, zda stáhnout a nainstalovat
  Microsoft Html Help Workshop, pokud není ve Vašem systému pøítomen.


Historie zmìn:
--------------
- v2.0 (27.4.2011)
  * pøidáno:    Vestavìný editor témat, jenž obsahuje zvýrazòování syntaxe, funkci dokonèování kódu,
                podporu vkládání textu pomocí klávesových zkratek, a také možnost využití aplikaèních doplòkù (viz níže).
                Všechny tyto funkce si mùžete nastavit a pøizpùsobit svým potøebám pomocí definice vlastních schémat syntaxe.
  * pøidáno:    Šablony témat. Kterékoliv téma lze uložit a používat jako šablonu
                (vèetnì automatické detekce použitých stylù, obrázkù, skriptù, atd.)
  * pøidáno:    Šablony projektù. Libovolný projekt, vèetnì témat, obrázkù, a dalších souborù, lze používat jako šablonu
  * pøidáno:    Aplikaèní doplòky. Funkènost produktu Precision Helper mùže být nyní libovolnì rozšiøována pomocí
                doplòkù. Implementováno je rozhraní pøíkazové øádky a skriptovacího jazyka Pascal Script (vèetnì vizuálního rozhraní).
  * pøidáno:    K dispozici jsou první doplòky, jako napø. HTML Tidy, Statistiky projektu, Editace obsahu a rejstøíku v externím editoru,
                Prùvodce vytvoøením nového projektu z existujících souborù témat, a další.
  * pøidáno:    Podpora více cílových formátù v hromadné kompilaci projektù (Chm, WebHelp, ePUB, atd.)
  * pøidáno:    Volba pro automatické zjištìní a zaøazení všech souborù využitých v projektu do sekce Soubory - FILES (pøi každém uložení projektu)
  * pøidáno:    Online nápovìda (WebHelp), jež je tvoøena navigaèními rámci (FRAMES), nyní obsahuje funkci pro pøímé nastavení se
                na zvolené téma. Tzn., že se z Vašich aplikací mùžete odkazovat na požadované téma v tomto typu nápovìdy,
                a to pomocí jednoduchých odkazù typu "c:\webhelp\index.htm#mytopic.htm", nebo "http://www.mysite.com/webhelp/index.php#mytopic.htm", apod.
  * pøidáno:    Automatické obnovení náhledu na téma pøi pøepnutí z externího editoru do Precision Helperu
  * pøidáno:    Pro funkci "Prozkoumat složku" vybraného souboru si mùžete zvolit (kromì Prùzkumníka Windows) také doplòkový (vlastní) souborový manažer
  * pøidáno:    Tlaèítko "Editovat obsah" pro otevøení vnoøeného obsahu k editaci v Precision Helperu
  * pøidáno:    Nová schémata barev uživatelského rozhraní (Windows 7, Office 2010, atd.)
  * pøidáno:    Šablona exportu do formátu WebHelp ("Extra separators") pro podporu specifických oddìlovaèù slov v jazycích jako èínština, japonština, apod.
  * pøidáno:    Tlaèítko "Nové okno" pro otevøení nové instance Precision Helper (v hlavní nabídce)
  * vylepšeno:  Poslední použité volby pro export (publikování) nápovìdy se nyní uchovávají pro každý projekt zvláš
  * vylepšeno:  Názvy témat obsahující apostrofy jsou nyní již podporovány pøi exportu do formátu WebHelp
  * vylepšeno:  Funkce vyhledávání (sekce Vyhledat) v exportované online nápovìdì (WebHelp) byla upravena tak,
                aby bylo možné celou nápovìdu vložit do elementu IFRAME.
  * vylepšeno:  Vyhledávání v online nápovìdì (WebHelp) již podporuje slova a výrazy s apostrofy.
  * vylepšeno:  Práce se soubory uloženými v kódování UTF8 (bez úvodních identifikaèních znakù). Takovéto soubory èinily problém hlavnì
                pøi exportu do formátu WebHelp a SingleHTML. Precision Helper nyní podporuje obì formy takovýchto souborù
                (a již se jedná o konfiguraèní soubory šablon, témata, aj.)
  * vylepšeno:  Vnitøní odkazy v nápovìdì exportované do formátu SingleHTML jsou nyní definovány jako &lt;A name="#..."&gt;&lt;/A&gt;
                (bez této definice, vèetnì uzavírajícího tagu, se odkazy chybnì zobrazovaly v nìkterých prohlížeèích, napø. Firefox a Opera)
  * vylepšeno:  V dialogu pro výbìr souboru projektu nyní mùžete pøepínat jednotlivá místa hledání pomocí klávesových zkratek Alt+Up a Alt+Down
  * opraveno:   Automatická synchronizace tématu a obsahu v online nápovìdì (WebHelp) byla opravena pro použití v Internet Exploreru,
                kde nefungovaly odkazy na adresy kódované v MIME/URL
  * opraveno:   Automatická synchronizace tématu a obsahu v online nápovìdì (WebHelp) se nyní správnì naviguje na témata
                se shodnými názvy, umístìná v rùzných vìtvích obsahu nápovìdy

  * opraveno:   Modální dialogy aplikace jsou nyní zobrazovány na aktuální ploše (pøi používání více monitorù)
  * opraveno:   Chyba pøi pøidávání prvního klíèového slova k tématu (v panelu pro rychlé pøidání klíèového slova),
                která se projevovala v nìkterých specifických situacích (napø. když byl rejstøík slov v projektu prázdný)
  * opraveno:   Pokud jste v Precision Helperu smazali veškeré definice kontextové nápovìdy, Precision Helper
                nevyèistil odpovídající sekce (MAP a ALIAS) v souboru projektu. Toto je nyní opraveno.


- v1.1 (1.7.2010)
  * pøidáno:    Publikování do formátu ePUB (e-book)
  * vylepšeno:  Výraznì vylepšen export do formátu WebHelp (online nápovìdy), vèetnì možnosti vyhledávání
  * pøidáno:    Oficiálnì byla pøidána Francouzská lokalizace
  * opraveno:   Témata definovaná lokálním odkazem (napø. "default.htm#section1") nebyla zobrazována v náhledu
                (toto je nyní opraveno, ale obecnì nedoporuèujeme v obsahu nebo rejstøíku takto definované odkazy používat)

- v1.0.4.10 (12.3.2010)
  * pøidáno:    ruská lokalizace
  * vylepšeno:  nìkolik tlaèítek a panelù bylo zvìtšeno tak, aby bylo možné zobrazit lokalizované texty v jiných jazycích
  * pøidáno:    do výbìrových dialogù pro zaøazení souborù do projektu nápovìdy byly pøidány pøípony multimediálních souborù *.mp3, *.wav, *.avi, *.wmv, *.mpg, *.mpeg and *.swf

- v1.0.3.28 (18.11.2009)
  * pøidáno:    polská lokalizace
  * pøidáno:    maïarská lokalizace
  * vylepšeno:  nìkolik tlaèítek a panelù bylo zvìtšeno tak, aby bylo možné zobrazit lokalizované texty v jiných jazycích
  * pøidáno:    tlaèítko pro rychlé skrytí panelu vlastností
  * pøidáno:    volba pro otevøení složky vybraného souboru v Prùzkumníku Windows (pro Seznam souborù, Seznam projektù a Kompilace)
  * vylepšeno:  horizontální posuvník v protokolu o kompilaci je nyní zobrazován dle potøeby
  * vylepšeno:  v dialogu 'Nastavení->Správa projektù' pøibyla volba 'Ukládat položky obsahu a rejstøíku v html kódování'
  * vylepšeno:  položky obsahu a rejstøíku kódované v html jsou nyní zobrazovány správnì (napø. "Èervená & Modrá" místo "Èervená &amp; Modrá")
  * doplnìno:   Import CHM - odkazy na témata v dekompilovaném projektu (vèetnì obsahu a rejstøíku) nyní obsahují 'opaèná lomítka', v souladu s tématy uvedenými v sekci 'FILES'.
                (pøed touto úpravou byly odkazy dekompilovány tak, jak byly uloženy v CHM, což v mnoha pøípadech vedlo k nechtìným rozdílùm mezi obsahem/rejstøíkem a sekcí 'FILES')
  * opraveno:   Import CHM - identifikátory kontextové nápovìdy jsou nyní dekompilovány i pro situaci, kdy jsou v rámci CHM uloženy pøímo v projektovém souboru (.hhp)
  * vylepšeno:  volba 'Otevøít poslední projekt pøi startu' nyní funguje i pøi spouštìní aplikace s parametrem /N
  * opraveno:   nìkolik drobných oprav v anglické nápovìdì (odkazy, texty)
  * opraveno:   tlaèítko 'Velikost textu' (v hlavním panelu nástrojù) je již možné lokalizovat
  * opraveno:   barevné schéma nyní funguje i pro kartu 'Nastavení->Externí nástroje'

- v1.0.2.16 (23.08.2009)
  * vylepšeno:  vylepšena kontrola jedné bìžící instance - aktuálnì bìžící instance se nyní nastavuje do popøedí
  * pøidáno:    soubor nápovìdy VirtualTreeview.chm byl pøidán do adresáøe Samples (pøíklady), pro demonstraci možností dekompilace na nezávislém projektu.
                Poznámka: dekompilovaný projekt nemùže být kompilován pomocí hhc.exe bez zaškrtnuté volby "Zobrazovat prùbìh kompilace" na nìkterých PC (je nutné použít výchozí kompilátor hha.dll).
                          Pokud je zmínìná volba zaškrtnuta, vše funguje správnì i s kompilátorem hhc.exe.
                Velice dìkujeme autoru komponenty VirtualTreeview za spolupráci (Mike Lischke, Soft-Gems, viz použité komponenty tøetích stran).
  * opraveno:   problém "Prohlížeèe CHM" a "Dialogu pro výbìr souboru projektu" s disketovými mechanikami (když byly jednotky A: nebo B: nainstalovány, ale nebyly v nich diskety)
  * opraveno:   rozvržení dialogu "Informace o aplikaci" na Windows XP bìžících pod Virtual PC (okno mìlo vìtší rozmìr než obrázek)
  * opraveno:   pøi pøetažení souborù myší z jiné aplikace do obsahu se nevyplnil název tématu (metoda kopírovat a vložit fungovala správnì)

- verze 1.0.1 (22.07.2009) je první veøejnì distribuovanou verzí


Použité komponenty a knihovny tøetích stran:
--------------------------------------------
- CodeGear Delphi 2009 for Win32 Professional, http://www.embarcadero.com/
- TMS Component Pack Professional, http://www.tmssoftware.com
- VirtualTree, http://www.soft-gems.net
- Precision Language Suite for VCL, http://www.be-precision.com
- Precision VCL, http://www.be-precision.com
- Delphi HH Kit (implementace IStorage), http://helpware.net/delphi/index.html
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
- KeyWorks Software a Work Write (pøíruèka chybových hlášení hhc.exe), http://www.keyworks.net, http://www.workwrite.com
- InnoSetup, http://www.jrsoftware.org
- ISTool, http://www.istool.org/
- IcoFX, http://icofx.ro/
- Rumshot, http://www.shellscape.org/rumshot/
- Fugue Small Icons, http://www.pinvoke.com/
- Silk Icons, http://www.famfamfam.com/lab/icons/silk/
- Developers Icons, http://sekkyumu.deviantart.com/art/Developpers-Icons-63052312
- Human O2 Icons, http://schollidesign.deviantart.com/art/Human-O2-Iconset-105344123
- Oxygen Icons, http://www.oxygen-icons.org/


Kontakt:
--------
Precision software & consulting
e-mail:  info@be-precision.com
www:     http://www.be-precision.com
podpora: www.be-precision.com/support
         support@be-precision.com
fórum:   www.be-precision.com/forum
rss:     www.be-precision.com/rss_cz.xml


========================================================
Copyright (c) 2008-2011  Precision software & consulting
Všechna práva vyhrazena.
