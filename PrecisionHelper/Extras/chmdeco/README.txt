chmdeco -- decompile CHM files and extract files from ITS files (future)
Copyright (C) 2003 Pabs, <pabs@zip.to>

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software Foundation,
Inc., 59 Temple Place, Suite 330, Boston, MA, 02111-1307, USA or visit:
http://www.gnu.org


About:

chmdeco is a program that converts the internal files of a CHM back into
the files that were used to create it: .hhp, .hhc, .hhk, .stp, alias & map
files etc.


Legalese:

Reuse and distribution of decompiled authoring files may constitute a violation
of copyright law. This is a tool for you own fair use (where available). For
example it is extremely useful for tailoring poorly designed help files to your
own liking and or recreating authoring files you may have lost. Fuck the DMCA!!!


Other implementations:

The decompile function of KeyTools by KeyWorks Software (Win32 GUI only) does
pretty much the same thing, except that chmdeco does it much better. Also
KeyTools extracts all the files compressed into the chm whereas chmdeco relies
on other programs for this (for now). There are probably other Win32 help
authoring tools that do decompiling, but I don't know which ones.


Dependencies:

You need a program that extracts files from InfoTech Storage files
(.its/.chm), so that chmdeco can get at the internal files it needs. On
Unix you can use chmdump by Matthew T. Russotto, which is available from
http://www.speakeasy.org/~russotto/chm/ or chmlib by Jed Wing, which is
available from http://66.93.236.84/~jedwin/projects/chmlib/. On Win32 you
can use istorage, which was written by me & is both included in the binary
distribution and available from http://pabs.zip.to/prog.html#istorage


Building, usage & testing:

On Windows:

1. The binary distribution contains prebuilt executables*.
2. Extract your chm by:
     dropping it onto the supplied istorage.exe
     using "Unpack with istorage" on the CHM context menu
	 using "Unpack with istorage" on the SendTo menu
3. Recreate the authoring files by:
     dropping the folder that istorage produced onto the supplied chmdeco.exe
     using "Decompile with chmdeco" on the folder context menu
	 using "Decompile with chmdeco" on the SendTo menu
4. Open the #recreated subfolder in the folder that istorage produced,
   look at the files there, and compare them to the originals if available
*. If you want to compile a Win32 version grab the source, edit the Makefile
   and compile under Cygwin/MingW. Other compilers that support the opendir/
   readdir/closedir functions should be able to compile with no problems.

On Unix:

#You should have done the next 2 lines already
#wget http://bonedaddy.net/pabs3/chm/chmdeco-<version>.tar.gz
#tar zxvf chmdeco-<version>.tar.gz
wget http://www.speakeasy.org/~russotto/chm/chmtools.tar.gz
tar zxvf chmtools.tar.gz
cd chmtools
make
cd ../chmdeco-<version>
./configure && make && sudo make install
cd ..
./chmdump/chmdump foo-bar.chm temp &> /dev/null
chmdeco-popups temp
less temp/#recreated/*.hhp
less temp/#recreated/*.hhc
less temp/#recreated/*.hhk
less temp/#recreated/*.stp
less temp/#recreated/*.ali
less temp/#recreated/*.h
diff -U foo-bar-authoring temp/#recreated > ./foo-bar.diff
less ./foo-bar.diff


Options:

Place these before any arguments they should apply to.

-p
	Turn on printing defaults in the [OPTIONS] section of the hhp
-b
	Turn off printing the blurb at the start of the hhp
-s
	Turn off printing the compilation stats at the start of the hhp
-h
	Print version and usage on stderr, then exit
-e
	Turn on converting the following characters in the hhc/hhk into entity refs
	& &amp;
	< &lt;
	> &gt;
	" &quot;
	� (0x99) &trade;
-f
	Turn on converting the full-text search information back into html files
--
	Turn off options processing for the rest of the arguments


Limitations:

Most of the problems with decompilation are because the internal files
don't store the desired info (*), but some stuff isn't implemented yet (@):

*the Binary Index/Binary TOC options are buggy when there are no hhc/hhk
@*the Auto TOC option is not output (can be got by cheating - read the .hhc)
@the hhs & the Sample Staging Path & Sample list file options aren't output
@the Flat option isn't output
*the Display compile notes, Display compile progress, Error log file,
 Enhanced decompilation (maybe @), and some undocumented options aren't output
*the stp file will be output 1 word per line, probably in different order

*the last argument of the [WINDOWS] section entries is always output

*the [FILES] section will contain all the non-internal files in the chm,
 not just those referenced in the original [FILES] section

@the alias/map files only contain IDH_1234 etc, not symbolic context ids

@the [TEXT POPUPS] section is not output
*and when it is the .txt files will not have symbolic context ids
*or any .comment lines
for now you can work around this problem using the chmdeco-popups.sh script (on
Unix), which  needs sh, chmdeco, cd, echo, find, xargs, grep, sed, tr and awk.
On Windows you can add the names of the text files that have lines beginning
with ".topic", then spaces and a number to the [TEXT POPUPS] section of the
recreated hhp file. If anyone has any ideas for automating this on Windows I'd
appreciate hearing them eg. Windows Scripting Host.

*the [INFOTYPES] section is empty
*the [SUBSETS] section is useless

@the hhc cannot be recovered when Binary TOC was off (but the options can)
*the Image Width, Color Mask and Auto Generated(@) options of the hhk are
 not recovered
*information types and Comment, ImageNumber and WindowName attributes from
 hhc items are not recovered
*multiple Name, Local pairs are not output
@some &amp; style characters may not be back converted
*no un-Merge-ing

*when you put the index in a [WINDOWS] section entry, but not the
 Index file option, then the hhk will not be recovered
*the Font, FrameName and WindowName options of the hhk are not recovered
*information types and Comment, FrameName and WindowName attributes from
 hhk items are not recovered
*the hhk will be sorted alphabetically
@any KLinks will be added to the hhk & you can't tell which they are without the
original hhk file
@some &amp; style characters may not be back converted
*no un-Merge-ing

@any Alinks will be removed from html files
*chmdeco can't recover Split html files (@maybe one day?)

*the recreated html files recreated from the full-text-search may have ???? in
them. This occurs when Microsoft's hhc apparently forgets that a word exists at
that position. This involves a word being repeated at least 3 times in a
document - normal, ending in single quote and ending in a period

@*probably more inconsistencies - please let me know of any more


More info:

I've written a specification on the internal files of CHMs and other related
stuff. It was released in late April/early June 2003, after was converted from
HTML into DocBook. The website is http://bonedaddy.net/pabs3/hhm/#chmspec


Enjoy
Pabs <pabs@zip.to>
http://pabs.zip.to
