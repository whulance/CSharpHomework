<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/ArrayOfOrder">
    <html>
      <head>
        <title>OrderList</title>
      </head>
      <body>
        <xsl:for-each select="Order">
          <table border ="3">
            <tr>
              <td>OrderDetails</td>
            </tr>
            <tr>
              <td>ProductName</td>
              <td>ProductNum</td>
              <td>ProductPrice</td>
            </tr>
            <xsl:for-each select="orderdetailsList">
              <tr>
                <xsl:for-each select="Orderdetails">
                  <tr>
                    <xsl:for-each select="*">
                      <td>
                        <xsl:value-of select="."/>
                      </td>
                    </xsl:for-each>
                  </tr>
                </xsl:for-each>
              </tr>
            </xsl:for-each>
            <tr>
              OrderID: <xsl:value-of select="OrderID"/>
            </tr>
            <xsl:for-each select="Customer">
              <tr>
                <td>Customer</td>
              </tr>
              <tr>
                <td>Name</td>
                <td>Customerphone</td>
              </tr>
              <tr>
                <td>
                  <xsl:value-of select="Name"/>
                </td>
                <td>
                  <xsl:value-of select="Customerphone"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
          <br/>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
