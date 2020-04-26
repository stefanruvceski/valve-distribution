[Kontrola chyb]
CmdLinePrms=-e -q

[Kontrola chyb - podrobná]
CmdLinePrms=-e

[Vyèistit]
CmdLinePrms=-m

[Reformát XML]
CmdLinePrms=-m --indent yes --indent-spaces 2 --input-xml yes --markup yes --output-xml yes --quiet yes --wrap 100 --wrap-asp yes --wrap-attributes yes --wrap-jste yes --wrap-php yes --write-back yes

[Vyèistit - zalomit]
CmdLinePrms=-m --bare no --clean no --fix-bad-comments yes --fix-backslash yes --indent yes --indent-attributes no --indent-spaces 2 --char-encoding raw --replace-color yes --wrap 80 --wrap-asp yes --wrap-jste yes --wrap-php yes --write-back yes

[Vyèistit - odsadit]
CmdLinePrms=-m --bare no --clean no --fix-bad-comments yes --fix-backslash yes --indent yes --indent-attributes no --indent-spaces 2 --char-encoding raw --replace-color yes --wrap 0 --wrap-asp no --wrap-jste no --wrap-php no --write-back yes

[Vyèistit - bez odsazení]
CmdLinePrms=-m --bare no --clean no --fix-bad-comments yes --fix-backslash yes --indent no --indent-attributes no --indent-spaces 2 --char-encoding raw --replace-color yes --wrap 0 --wrap-asp no --wrap-jste no --wrap-php no --write-back yes

[Vyèistit dokument Microsoft Word 2000]
CmdLinePrms=-m --doctype auto --drop-empty-paras yes --fix-bad-comments yes --fix-uri yes --join-styles yes --lower-literals yes --ncr yes --quote-ampersand yes --quote-nbsp yes --word-2000 yes --markup yes --wrap-jste yes --wrap-php yes --wrap-section yes --write-back yes

[Vyèistit - použít HTML entity]
CmdLinePrms=-m --quote-ampersand yes --quote-marks yes --quote-nbsp yes --write-back yes

[Upgrade na CSS]
CmdLinePrms=-m --add-xml-decl no --add-xml-pi no --alt-text Image --break-before-br no --clean yes --doctype auto --drop-empty-paras no --drop-font-tags yes --fix-backslash yes --fix-bad-comments yes --hide-endtags no --char-encoding raw --indent yes --indent-spaces 2 --input-xml no --markup yes --quiet yes --tidy-mark no --uppercase-attributes no --uppercase-tags no --word-2000 yes --wrap 100 --wrap-asp yes --wrap-attributes yes --wrap-jste yes --wrap-php yes --write-back yes

[Pøevést do XML]
CmdLinePrms=-m --add-xml-decl yes --add-xml-pi yes --alt-text Image --break-before-br no --clean yes --doctype AUTO --drop-empty-paras no --drop-font-tags yes --fix-bad-comments yes --hide-endtags no --char-encoding raw --indent yes --indent-spaces 2 --input-xml no --markup yes --output-xml yes --quiet yes --tidy-mark no --uppercase-attributes no --uppercase-tags no --word-2000 no --wrap 100 --wrap-asp yes --wrap-attributes yes --wrap-jste yes --wrap-php yes --write-back yes

[Pøevést do XHTML]
CmdLinePrms=-m --add-xml-decl no --add-xml-pi no --alt-text Image --break-before-br no --clean yes --doctype auto --drop-empty-paras no --drop-font-tags yes --error-file error.log --fix-backslash yes --fix-bad-comments yes --hide-endtags no --char-encoding raw --indent yes --indent-spaces 2 --input-xml no --logical-emphasis yes --lower-literals yes --markup yes --output-xhtml yes --output-xml no --quiet yes --tidy-mark no --uppercase-attributes no --uppercase-tags no --word-2000 no --wrap 100 --wrap-asp yes --wrap-attributes yes --wrap-jste yes --wrap-php yes --write-back yes
