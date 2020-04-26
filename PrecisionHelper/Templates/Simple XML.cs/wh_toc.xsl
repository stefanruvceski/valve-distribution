<?xml version="1.0" encoding="windows-1250"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="windows-1250" media-type="text/html"/>
<xsl:template match="/">
	<html>
		<HEAD>
			<TITLE></TITLE>
		</HEAD>
		<body style="border:none;">
      <form>
        <input TYPE="button" VALUE="  Obsah  " ONCLICK="location = 'wh_toc.xml';" NAME="Help Topics" />&#160;
        <input TYPE="button" VALUE=" Rejstřík " ONCLICK="location = 'wh_index.xml';" NAME="Index" /><br /><br />

			  <TABLE style="font-family:'Segoe UI, Tahoma, Arial';font-size:9pt;">
				  <TBODY>
          <xsl:apply-templates select="TOC/ITEM"/>
				  </TBODY>
			  </TABLE>
      </form>
		</body>
	</html>
</xsl:template> 
<xsl:template match="ITEM">
	<TR>
		<TD>
			<NOBR>
  			<xsl:for-each select="../ancestor::*">
				&#160;&#160;&#160;&#160;
	  		</xsl:for-each>
				<SPAN>
					<xsl:attribute name="style">
						position:relative;
						left:20px;
						padding-right:24px;
					</xsl:attribute>
					<img style="position:absolute;left:-22px;top:2px;">
						<xsl:attribute name="src">
						  <xsl:if test="@imagenumber='1'">
						    images/1.gif
  					  </xsl:if>
						  <xsl:if test="(string-length(@imagenumber)=0) or (@imagenumber!='1')">
						    images/9.gif
  					  </xsl:if>
						</xsl:attribute>
					</img>
				  <xsl:if test="string-length(@url)>0 or string-length(@alt)>0">
					  <A target="right">
					    <xsl:attribute name="href"><xsl:value-of select="@url"/></xsl:attribute>
					    <xsl:attribute name="alt"><xsl:value-of select="@alt"/></xsl:attribute>
              <xsl:value-of disable-output-escaping="yes" select="@name"/>
            </A>
          </xsl:if>
          <xsl:if test="string-length(@url)=0 and string-length(@alt)=0">
            <xsl:value-of disable-output-escaping="yes" select="@name"/>
          </xsl:if>
				</SPAN>
			</NOBR>
		</TD>
		<xsl:apply-templates select="ITEM"/>
	</TR>
</xsl:template> 
</xsl:stylesheet>
