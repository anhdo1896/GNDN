using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CBDN.TonThatKyThuatReport
{
    public class DuyetCanhBaoTTKD 
    {
            public DataTable DCB_TKD(DataTable dtKhang, float tylebt, int t,int thang,int nam,string Ma_dvi,string Matram)
        {
            DataAccess.clTTTT db = new DataAccess.clTTTT();
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
                var tbsl1 = sl_check1/sanluong_1 *100;
                var tbsl2 = sl_check2 / sanluong_2 *100;
                var tbsl3 = sl_check3 / sanluong_3 *100;
                var tb1 = tbsl1 - tbsl2;
                var tb2 = tbsl2 - tbsl3;
                var tb3 = tbsl1 - tbsl3;
                //H0 - Cháy hỏng
                if (sanluong <=2 && sanluong_1 > 10 && sanluong_2 > 10)
                {
                    if ((dtKhang.Rows[i]["CANH_BAO"] + "") != "")
                    {
                        dtKhang.Rows[i]["CANH_BAO"] = "Có thể " + dtKhang.Rows[0]["CANH_BAO"] + ", " + "Có thể chết cháy kẹt sản lượng không tăng hoặc tăng rất nhỏ so với tháng trước";
                    }
                    else
                    {
                        dtKhang.Rows[i]["CANH_BAO"] = "Có thể chết cháy kẹt sản lượng không tăng hoặc tăng rất nhỏ so với tháng trước";
                    }
                    dtKhang.Rows[i]["MA_TTCTO"] = "C2";
                    dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra và thay tháo công tơ";
                  //GD - Ghi đè    
                }   
                if(sl_check1 == 0)
                {
                    dtKhang.Rows[i]["MA_TTCTO"] = "C1";
                    dtKhang.Rows[i]["CANH_BAO"] = "Có thể " + "Chết cháy kẹt với chỉ số bằng 0";
                        dtKhang.Rows[i]["DX_CANH_BAO"] = "Tháo công tơ thay thế	";
                }
                if (tb1 > 0)
                {
                    if (tb1 > tylebt)
                    {
                        //T2 - Sản lượng tăng bất thường 2 tháng
                        if (Math.Abs(tb2) > tylebt && Math.Abs(tb3) < tylebt || Math.Abs(tb2) < tylebt && Math.Abs(tb3) > tylebt)
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "T2";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng tăng bất thường trong 2 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                        //T3 - Sản lượng tăng bất thường trong 3 tháng
                        else if (Math.Abs(tb2) > tylebt && Math.Abs(tb3) > tylebt)
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
                    if (Math.Abs(tb1) > tylebt)
                    {
                        if (Math.Abs(tb2) > tylebt && Math.Abs(tb3) > tbsl3)
                        {
                            dtKhang.Rows[i]["MA_TTCTO"] = "G3";
                            dtKhang.Rows[i]["CANH_BAO"] = "Sản lượng giảm bất thường trong 3 tháng";
                            dtKhang.Rows[i]["DX_CANH_BAO"] = "Kiểm tra lại công tơ";
                        }
                        else if(Math.Abs(tb2) < tylebt && Math.Abs(tb3) > tylebt|| Math.Abs(tb2) > tylebt && Math.Abs(tb3) < tylebt)
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
            //Insert vào DB
            /*
            for (int j = 0; i < a; j++)
            {
                string check = dtKhang.Rows[i]["MA_TTCTO"] + "";
                if (check != "")
                {
                    db.INSERT_TBDD_PT_CHISO_KH(dtKhang.Rows[i]["MA_DVIQLY"]+"", dtKhang.Rows[i]["MATRAM"] + "", dtKhang.Rows[i]["MAKHACHHANG"] + "", dtKhang.Rows[i]["MA_NN"] + "",
                    dtKhang.Rows[i]["TENKHACHHANG"] + "", dtKhang.Rows[i]["DIACHI"] + "", dtKhang.Rows[i]["MA_TTCTO"] + "", dtKhang.Rows[i]["CANH_BAO"] + "",
                    dtKhang.Rows[i]["DX_CANH_BAO"] + "", dtKhang.Rows[i]["MA_CLOAI"] + "",
                    dtKhang.Rows[i]["SO_CTO"] + "", dtKhang.Rows[i]["SAN_LUONG"] + "", dtKhang.Rows[i]["SLUONG_1"] + "", dtKhang.Rows[i]["SLUONG_2"] + "",
                    dtKhang.Rows[i]["SLUONG_3"] + "", dtKhang.Rows[i]["SOHO"] + "", dtKhang.Rows[i]["HANKD"] + "");

                }
            }
            */



            DataTable dt = new DataTable();
                dt.Columns.Add("MA_DVIQLY");
                dt.Columns.Add("MATRAM");
                dt.Columns.Add("MAKHACHHANG");
                dt.Columns.Add("MA_NN");
                dt.Columns.Add("TENKHACHHANG");
                dt.Columns.Add("DIACHI");
                dt.Columns.Add("MA_TTCTO");
                dt.Columns.Add("CANH_BAO");
                dt.Columns.Add("DX_CANH_BAO");
                dt.Columns.Add("MA_CLOAI");
                dt.Columns.Add("SO_CTO");
                dt.Columns.Add("SAN_LUONG");
                dt.Columns.Add("SLUONG_1");
                dt.Columns.Add("SLUONG_2");
                dt.Columns.Add("SLUONG_3");
                dt.Columns.Add("SOHO");
                dt.Columns.Add("HANKD");
                int k = dtKhang.Rows.Count;
                int j = 1;
                for(int i = 0; i<k; i++)
                {
                    string check = dtKhang.Rows[i]["MA_TTCTO"] + "";
                    if (check != "")
                    {
                        dt.Rows.Add(dtKhang.Rows[i]["MA_DVIQLY"],dtKhang.Rows[i]["MATRAM"],dtKhang.Rows[i]["MAKHACHHANG"],dtKhang.Rows[i]["MA_NN"],
                        dtKhang.Rows[i]["TENKHACHHANG"],dtKhang.Rows[i]["DIACHI"],dtKhang.Rows[i]["MA_TTCTO"],dtKhang.Rows[i]["CANH_BAO"],
                        dtKhang.Rows[i]["DX_CANH_BAO"],dtKhang.Rows[i]["MA_CLOAI"],
                        dtKhang.Rows[i]["SO_CTO"],dtKhang.Rows[i]["SAN_LUONG"],dtKhang.Rows[i]["SLUONG_1"],dtKhang.Rows[i]["SLUONG_2"],
                        dtKhang.Rows[i]["SLUONG_3"],dtKhang.Rows[i]["SOHO"],dtKhang.Rows[i]["HANKD"]);
                        j++;
                    }    
                }
                if(dt.Rows.Count != 0)
            {

                //Kiểm tra xem dữ liệu được chèn vào bảng TBDD_PT_CHISO
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT_B10_CHECK(Ma_dvi, Matram, thang, nam);
                int a1 = ds.Rows.Count;
                //Nếu có dữ liệu rồi ktra với TBDD_PT_CHISO_TRAM_B10 có dữ liệu chưa và nếu có thì tybt có trùng nhau không
                //Nếu trùng thì dữ nguyên, nếu không trùng tiến hành xoá ở TBDD_PT_CHISO rồi insert TBDD_PT_CHISO và insert DL vào lại bảng TBDD_PT_CHISO_TRAM_B10
                if (a1==1)
                {     
                    
                    DataTable check = db.SELECT_THONGTIN_TRAM_TLTT_B10_TEMP_Check(Ma_dvi, Matram, thang, nam, tylebt);
                    int check1 = check.Rows.Count;
                    if (check1 == 0)
                    {
                        float dnn = 0;
                        float dntt = 0;
                        float tt_lk = 0;
                        int nn = 0;
                        int tt = 0;
                        db.DELETE_KHANG_PHUCTRA_TRAM(Ma_dvi, Matram, "DDK", "0A", thang, nam, 0);
                        db.Insert_Khang_PhucTra(dt, thang, nam, Ma_dvi);
                        ds = db.SELECT_THONGTIN_TRAM_TLTT_B10_CHECK(Ma_dvi, Matram, thang, nam);
                        string ten_tram = ds.Rows[0]["TEN_TRAM"] + "";
                        int csuat_tram = int.Parse(ds.Rows[0]["CSUAT_TRAM"] + "");
                        string DNN = ds.Rows[0]["DNN"] + "";
                        string TT_LK = ds.Rows[0]["TT_LK"] + "";
                        string NGUYEN_NHAN = ds.Rows[0]["NGUYEN_NHAN"] + "";
                        string TINH_TRANG = ds.Rows[0]["TINH_TRANG"] + "";
                        string DNTT = ds.Rows[0]["DNTT"] + "";
                        if (DNN != "") { dnn = float.Parse(DNN); }
                        if (TT_LK != "") { tt_lk = float.Parse(TT_LK); }
                        if (NGUYEN_NHAN != "") { nn = int.Parse(NGUYEN_NHAN); }
                        if (TINH_TRANG != "") { tt = int.Parse(TINH_TRANG); }
                        if (DNTT != "") { dntt = float.Parse(DNTT); }
                        db.INSERT_THONGTIN_TRAM_TLTT_B10(Ma_dvi, Matram, ten_tram, csuat_tram, dnn, tt_lk, dntt, nn,  tt, thang, nam, tylebt);
                      
                    }

                }
                else if (a1 == 0)
                        {
                    float dnn = 0;
                    float dntt = 0;
                    float tt_lk = 0;
                    int nn = 0;
                    int tt = 0;
                    db.Insert_Khang_PhucTra(dt, thang, nam, Ma_dvi);
                    ds = db.SELECT_THONGTIN_TRAM_TLTT_B10_CHECK(Ma_dvi, Matram, thang, nam);
                    string ten_tram = ds.Rows[0]["TEN_TRAM"] + "";
                    int csuat_tram = int.Parse(ds.Rows[0]["CSUAT_TRAM"] + "");
                    string DNN = ds.Rows[0]["DNN"] + "";
                    string TT_LK = ds.Rows[0]["TT_LK"] + "";
                    string NGUYEN_NHAN = ds.Rows[0]["NGUYEN_NHAN"] + "";
                    string TINH_TRANG = ds.Rows[0]["TINH_TRANG"] + "";
                    string DNTT = ds.Rows[0]["DNTT"] + "";
                    if (DNN != "") { dnn = float.Parse(DNN); }
                    if (TT_LK != "") { tt_lk = float.Parse(TT_LK); }
                    if (NGUYEN_NHAN != "") { nn = int.Parse(NGUYEN_NHAN); }
                    if (TINH_TRANG != "") { tt = int.Parse(TINH_TRANG); }
                    if (DNTT != "") { dntt = float.Parse(DNTT); }
                    db.INSERT_THONGTIN_TRAM_TLTT_B10(Ma_dvi, Matram, ten_tram, csuat_tram, dnn, tt_lk, dntt, nn, tt, thang, nam, tylebt);

                }

            }    

            if (t != 0)
            {
                return dt;
            }
            return dtKhang;
        }
    }
}