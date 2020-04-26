tidy [option...] [file...] [option...] [file...]
Utility to clean up and pretty print HTML/XHTML/XML
See http://tidy.sourceforge.net/

Options for HTML Tidy for Windows released on 25 March 2009:

File manipulation
-----------------
 -output <file>, -o  write output to the specified <file>                      
 <file>                                                                        
 -config <file>      set configuration options from the specified <file>       
 -file <file>, -f    write errors and warnings to the specified <file>         
 <file>                                                                        
 -modify, -m         modify the original input files                           

Processing directives
---------------------
 -indent, -i         indent element content                                    
 -wrap <column>, -w  wrap text at the specified <column>. 0 is assumed if      
 <column>            <column> is missing. When this option is omitted, the     
                     default of the configuration option "wrap" applies.       
 -upper, -u          force tags to upper case                                  
 -clean, -c          replace FONT, NOBR and CENTER tags by CSS                 
 -bare, -b           strip out smart quotes and em dashes, etc.                
 -numeric, -n        output numeric rather than named entities                 
 -errors, -e         show only errors and warnings                             
 -quiet, -q          suppress nonessential output                              
 -omit               omit optional end tags                                    
 -xml                specify the input is well formed XML                      
 -asxml, -asxhtml    convert HTML to well formed XHTML                         
 -ashtml             force XHTML to well formed HTML                           
 -access <level>     do additional accessibility checks (<level> = 0, 1, 2, 3).
                     0 is assumed if <level> is missing.                       

Character encodings
-------------------
 -raw                output values above 127 without conversion to entities    
 -ascii              use ISO-8859-1 for input, US-ASCII for output             
 -latin0             use ISO-8859-15 for input, US-ASCII for output            
 -latin1             use ISO-8859-1 for both input and output                  
 -iso2022            use ISO-2022 for both input and output                    
 -utf8               use UTF-8 for both input and output                       
 -mac                use MacRoman for input, US-ASCII for output               
 -win1252            use Windows-1252 for input, US-ASCII for output           
 -ibm858             use IBM-858 (CP850+Euro) for input, US-ASCII for output   
 -utf16le            use UTF-16LE for both input and output                    
 -utf16be            use UTF-16BE for both input and output                    
 -utf16              use UTF-16 for both input and output                      
 -big5               use Big5 for both input and output                        
 -shiftjis           use Shift_JIS for both input and output                   
 -language <lang>    set the two-letter language code <lang> (for future use)  

Miscellaneous
-------------
 -version, -v        show the version of Tidy                                  
 -help, -h, -?       list the command line options                             
 -xml-help           list the command line options in XML format               
 -help-config        list all configuration options                            
 -xml-config         list all configuration options in XML format              
 -show-config        list the current configuration settings                   

Use --optionX valueX for any configuration option "optionX" with argument
"valueX". For a list of the configuration options, use "-help-config" or refer
to the man page.

Input/Output default to stdin/stdout respectively.
Single letter options apart from -f may be combined
as in:  tidy -f errs.txt -imu foo.html
For further info on HTML see http://www.w3.org/MarkUp


HTML Tidy Configuration Settings

Within a file, use the form:

wrap: 72
indent: no

When specified on the command line, use the form:

--wrap 72 --indent no

Name                        Type       Allowable values
=========================== =========  ========================================
accessibility-check         enum       0 (Tidy Classic), 1 (Priority 1 Checks),
                                       2 (Priority 2 Checks), 3 (Priority 3
                                       Checks)
add-xml-decl                Boolean    y/n, yes/no, t/f, true/false, 1/0
add-xml-space               Boolean    y/n, yes/no, t/f, true/false, 1/0
alt-text                    String     -
anchor-as-name              Boolean    y/n, yes/no, t/f, true/false, 1/0
ascii-chars                 Boolean    y/n, yes/no, t/f, true/false, 1/0
assume-xml-procins          Boolean    y/n, yes/no, t/f, true/false, 1/0
bare                        Boolean    y/n, yes/no, t/f, true/false, 1/0
break-before-br             Boolean    y/n, yes/no, t/f, true/false, 1/0
char-encoding               Encoding   raw, ascii, latin0, latin1, utf8,
                                       iso2022, mac, win1252, ibm858, utf16le,
                                       utf16be, utf16, big5, shiftjis
clean                       Boolean    y/n, yes/no, t/f, true/false, 1/0
css-prefix                  String     -
decorate-inferred-ul        Boolean    y/n, yes/no, t/f, true/false, 1/0
doctype                     DocType    omit, auto, strict, transitional, user
drop-empty-paras            Boolean    y/n, yes/no, t/f, true/false, 1/0
drop-font-tags              Boolean    y/n, yes/no, t/f, true/false, 1/0
drop-proprietary-attributes Boolean    y/n, yes/no, t/f, true/false, 1/0
enclose-block-text          Boolean    y/n, yes/no, t/f, true/false, 1/0
enclose-text                Boolean    y/n, yes/no, t/f, true/false, 1/0
error-file                  String     -
escape-cdata                Boolean    y/n, yes/no, t/f, true/false, 1/0
fix-backslash               Boolean    y/n, yes/no, t/f, true/false, 1/0
fix-bad-comments            Boolean    y/n, yes/no, t/f, true/false, 1/0
fix-uri                     Boolean    y/n, yes/no, t/f, true/false, 1/0
force-output                Boolean    y/n, yes/no, t/f, true/false, 1/0
gnu-emacs                   Boolean    y/n, yes/no, t/f, true/false, 1/0
gnu-emacs-file              String     -
hide-comments               Boolean    y/n, yes/no, t/f, true/false, 1/0
hide-endtags                Boolean    y/n, yes/no, t/f, true/false, 1/0
indent                      AutoBool   auto, y/n, yes/no, t/f, true/false, 1/0
indent-attributes           Boolean    y/n, yes/no, t/f, true/false, 1/0
indent-cdata                Boolean    y/n, yes/no, t/f, true/false, 1/0
indent-spaces               Integer    0, 1, 2, ...
input-encoding              Encoding   raw, ascii, latin0, latin1, utf8,
                                       iso2022, mac, win1252, ibm858, utf16le,
                                       utf16be, utf16, big5, shiftjis
input-xml                   Boolean    y/n, yes/no, t/f, true/false, 1/0
join-classes                Boolean    y/n, yes/no, t/f, true/false, 1/0
join-styles                 Boolean    y/n, yes/no, t/f, true/false, 1/0
keep-time                   Boolean    y/n, yes/no, t/f, true/false, 1/0
language                    String     -
literal-attributes          Boolean    y/n, yes/no, t/f, true/false, 1/0
logical-emphasis            Boolean    y/n, yes/no, t/f, true/false, 1/0
lower-literals              Boolean    y/n, yes/no, t/f, true/false, 1/0
markup                      Boolean    y/n, yes/no, t/f, true/false, 1/0
merge-divs                  AutoBool   auto, y/n, yes/no, t/f, true/false, 1/0
merge-spans                 AutoBool   auto, y/n, yes/no, t/f, true/false, 1/0
ncr                         Boolean    y/n, yes/no, t/f, true/false, 1/0
new-blocklevel-tags         Tag names  tagX, tagY, ...
new-empty-tags              Tag names  tagX, tagY, ...
new-inline-tags             Tag names  tagX, tagY, ...
new-pre-tags                Tag names  tagX, tagY, ...
newline                     enum       LF, CRLF, CR
numeric-entities            Boolean    y/n, yes/no, t/f, true/false, 1/0
output-bom                  AutoBool   auto, y/n, yes/no, t/f, true/false, 1/0
output-encoding             Encoding   raw, ascii, latin0, latin1, utf8,
                                       iso2022, mac, win1252, ibm858, utf16le,
                                       utf16be, utf16, big5, shiftjis
output-file                 String     -
output-html                 Boolean    y/n, yes/no, t/f, true/false, 1/0
output-xhtml                Boolean    y/n, yes/no, t/f, true/false, 1/0
output-xml                  Boolean    y/n, yes/no, t/f, true/false, 1/0
preserve-entities           Boolean    y/n, yes/no, t/f, true/false, 1/0
punctuation-wrap            Boolean    y/n, yes/no, t/f, true/false, 1/0
quiet                       Boolean    y/n, yes/no, t/f, true/false, 1/0
quote-ampersand             Boolean    y/n, yes/no, t/f, true/false, 1/0
quote-marks                 Boolean    y/n, yes/no, t/f, true/false, 1/0
quote-nbsp                  Boolean    y/n, yes/no, t/f, true/false, 1/0
repeated-attributes         enum       keep-first, keep-last
replace-color               Boolean    y/n, yes/no, t/f, true/false, 1/0
show-body-only              AutoBool   auto, y/n, yes/no, t/f, true/false, 1/0
show-errors                 Integer    0, 1, 2, ...
show-warnings               Boolean    y/n, yes/no, t/f, true/false, 1/0
slide-style                 String     -
sort-attributes             enum       none, alpha
split                       Boolean    y/n, yes/no, t/f, true/false, 1/0
tab-size                    Integer    0, 1, 2, ...
tidy-mark                   Boolean    y/n, yes/no, t/f, true/false, 1/0
uppercase-attributes        Boolean    y/n, yes/no, t/f, true/false, 1/0
uppercase-tags              Boolean    y/n, yes/no, t/f, true/false, 1/0
vertical-space              Boolean    y/n, yes/no, t/f, true/false, 1/0
word-2000                   Boolean    y/n, yes/no, t/f, true/false, 1/0
wrap                        Integer    0 (no wrapping), 1, 2, ...
wrap-asp                    Boolean    y/n, yes/no, t/f, true/false, 1/0
wrap-attributes             Boolean    y/n, yes/no, t/f, true/false, 1/0
wrap-jste                   Boolean    y/n, yes/no, t/f, true/false, 1/0
wrap-php                    Boolean    y/n, yes/no, t/f, true/false, 1/0
wrap-script-literals        Boolean    y/n, yes/no, t/f, true/false, 1/0
wrap-sections               Boolean    y/n, yes/no, t/f, true/false, 1/0
write-back                  Boolean    y/n, yes/no, t/f, true/false, 1/0
