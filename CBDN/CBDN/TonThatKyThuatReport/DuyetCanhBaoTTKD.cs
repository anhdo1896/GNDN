using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CBDN.TonThatKyThuatReport
{
    public class DuyetCanhBaoTTKD 
    {
            public DataTable DCB_TKD(DataTable dtKhang)
        {
            CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
            int a = dtKhang.Rows.Count;
            for(int i = 0; i<a; i++)
            {
              float sanluong = float.Parse(dtKhang.Rows[i]["SAN_LUONG"] + "");
                float sanluong_1 = float.Parse(dtKhang.Rows[i]["SLUONG_1"] + "");
                float sanluong_2 = float.Parse(dtKhang.Rows[i]["SLUONG_2"] + "");
                float sanluong_3 = float.Parse(dtKhang.Rows[i]["SLUONG_3"] + "");
                var sl_check1 = sanluong - sanluong_1;
                var sl_check2 = sanluong_1 - sanluong_2;
                var sl_check3 = sanluong_2 - sanluong_3;
                var sl_tb = (sanluong + sanluong_1 + sanluong_2 + sanluong_3) / 4;
                var tbsl1 = sanluong_1 * 30 / 100;
                var tbsl2 = sanluong_2 * 30 / 100;
                var tbsl3 = sanluong_3 * 30 / 100;
                var tb1 = tbsl1 - tbsl2;
                var tb2 = tbsl2 - tbsl3;
                var tb3 = tbsl1 - tbsl3;
                //H - Cháy hỏng
                if (sanluong <=2 && sanluong_1 > 10 && sanluong_2 > 10)
                {
                    if ((dtKhang.Rows[i]["CANH_BAO"] + "") != "")
                    {
                        dtKhang.Rows[i]["CANH_BAO"] = "Có thể " + dtKhang.Rows[0]["CANH_BAO"] + ", " + "Cháy hỏng công tơ";
                    }
                    else
                    {
                        dtKhang.Rows[i]["CANH_BAO"] = "Có thể " + "Cháy hỏng công tơ";
                    }
                    dtKhang.Rows[i]["MA_TTCTO"] = "H";
                    dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra và thay thế công tơ";
                  //GD - Ghi đè    
                }   
                if(sl_check1 == 0)
                {
                    dtKhang.Rows[i]["MA_TTCTO"] = "D0";
                    dtKhang.Rows[i]["CANH_BAO"] = "Có thể " + "Sản lượng ghi đè";
                        dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                }
                if (tb1 > 0)
                {
                    if (tb1 > 30)
                    {
                        //T2 - Sản lượng tăng bất thường 2 tháng
                        if (Math.Abs(tb2) > 30 && Math.Abs(tb3) < 30 || Math.Abs(tb2) < 30 && Math.Abs(tb3) > 30)
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "T2";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng tăng bất thường trong 2 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                        //T3 - Sản lượng tăng bất thường trong 3 tháng
                        else if (Math.Abs(tb2) > 30 && Math.Abs(tb3) > 30)
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "T3";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng tăng bất thường trong 3 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                        //ST1 - Sản lượng tăng bất thường trong 1 tháng
                        else
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "T1";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng tăng bất thường trong 1 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }

                    }
                }
                if (tb1 < 0)
                {
                    if (Math.Abs(tb1) > 30)
                    {
                        if (Math.Abs(tb2) > 30 && Math.Abs(tb3) > tbsl3)
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "G3";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng giảm bất thường trong 3 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                        else if(Math.Abs(tb2) < 30 && Math.Abs(tb3) > 30|| Math.Abs(tb2) > 30 && Math.Abs(tb3) < 30)
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "G2";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng giảm bất thường trong 2 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                        else
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "G1";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng giảm bất thường trong 1 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                    }
                }
            }    








            return dtKhang;
        }
    }
}