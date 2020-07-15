using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Class
{
    public class XuatXML_GCS
    {
        public string HTML_XuatFileCMIS()
        {
            string XML = @"<?xml version='1.0' standalone='yes'?>
                                <NewDataSet>
                                  <xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata'>
                                    <xs:element name='NewDataSet' msdata:IsDataSet='true' msdata:UseCurrentLocale='true'>
                                      <xs:complexType>
                                        <xs:choice minOccurs='0' maxOccurs='unbounded'>
                                          <xs:element name='Table1'>
                                            <xs:complexType>
                                              <xs:sequence>
                                                <xs:element name='MA_NVGCS' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_KHANG' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_DDO' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_DVIQLY' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_GC' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_QUYEN' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_TRAM' type='xs:string' minOccurs='0' />
                                                <xs:element name='BOCSO_ID' type='xs:long' minOccurs='0' />
                                                <xs:element name='LOAI_BCS' type='xs:string' minOccurs='0' />
                                                <xs:element name='LOAI_CS' type='xs:string' minOccurs='0' />
                                                <xs:element name='TEN_KHANG' type='xs:string' minOccurs='0' />
                                                <xs:element name='DIA_CHI' type='xs:string' minOccurs='0' />
                                                <xs:element name='MA_NN' type='xs:string' minOccurs='0' />
                                                <xs:element name='SO_HO' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='MA_CTO' type='xs:string' minOccurs='0' />
                                                <xs:element name='SERY_CTO' type='xs:string' minOccurs='0' />
                                                <xs:element name='HSN' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='CS_CU' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='TTR_CU' type='xs:string' minOccurs='0' />
                                                <xs:element name='SL_CU' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='SL_TTIEP' type='xs:int' minOccurs='0' />
                                                <xs:element name='NGAY_CU' msdata:DateTimeMode='Unspecified' type='xs:dateTime' minOccurs='0' />
                                                <xs:element name='CS_MOI' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='TTR_MOI' type='xs:string' minOccurs='0' />
                                                <xs:element name='SL_MOI' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='CHUOI_GIA' type='xs:string' minOccurs='0' />
                                                <xs:element name='KY' type='xs:int' minOccurs='0' />
                                                <xs:element name='THANG' type='xs:int' minOccurs='0' />
                                                <xs:element name='NAM' type='xs:int' minOccurs='0' />
                                                <xs:element name='NGAY_MOI' msdata:DateTimeMode='Unspecified' type='xs:dateTime' minOccurs='0' />
                                                <xs:element name='NGUOI_GCS' type='xs:string' minOccurs='0' />
                                                <xs:element name='SL_THAO' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='KIMUA_CSPK' type='xs:short' minOccurs='0' />
                                                <xs:element name='MA_COT' type='xs:string' minOccurs='0' />
                                                <xs:element name='SLUONG_1' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='SLUONG_2' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='SLUONG_3' type='xs:decimal' minOccurs='0' />
                                                <xs:element name='SO_HOM' type='xs:string' minOccurs='0' />
                                                <xs:element name='PMAX' type='xs:decimal' minOccurs='0' /> 
                                                <xs:element name='NGAY_PMAX' msdata:DateTimeMode='Unspecified' type='xs:dateTime' minOccurs='0' /> 
                                              </xs:sequence>
                                            </xs:complexType>
                                          </xs:element>
                                        </xs:choice>
                                      </xs:complexType>
                                    </xs:element>
                                  </xs:schema>";
            return XML;
        }
    }
}