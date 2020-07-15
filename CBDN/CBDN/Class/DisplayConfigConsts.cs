using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBDN.Class
{
    public class DisplayConfigConsts
    {
        public static int TOP_LEFT_LOCATION = 1;
        public static int TOP_RIGHT_LOCATION = 2;
        public static int BOTTOM_LEFT_LOCATION = 3;
        public static int BOTTOM_RIGHT_LOCATION = 4;
        public static int USER_DEFINE_LOCATION = 5;
        public static int LOCATE_SIGN_DEFAULT = BOTTOM_LEFT_LOCATION;

        public static int NUMBER_PAGE_SIGN_DEFAULT = 1;
        public static float WIDTH_RECTANGLE_DEFAULT = 200;
        public static float HEIGHT_RECTANGLE_DEFAULT = 50;
        public static float MARGIN_TOP_OF_RECTANGLE_DEFAULT = 20f;
        public static float MARGIN_BOTTOM_OF_RECTANGLE_DEFAULT = 20f;
        public static float MARGIN_RIGHT_OF_RECTANGLE_DEFAULT = 220f;
        public static float MARGIN_LEFT_OF_RECTANGLE_DEFAULT = 230f;

        //text format of Rectangle to show contact, signDate, reason, location. 
        public static String SIGN_TEXT_FORMAT_1 = "Người Ký: %s";
        public static String SIGN_TEXT_FORMAT_2 = "Người Ký: %s\r\nNgày Ký: %s";
        public static String SIGN_TEXT_FORMAT_3 = "Người Ký: %s\r\nNgày Ký: %s\r\nLý Do: %s";
        public static String SIGN_TEXT_FORMAT_4 = "Người Ký: %s\r\nNgày Ký: %s\r\nLý Do: %s\r\nĐịa Điểm: %s";
        public static String SIGN_TEXT_FORMAT_5 = "Digital signed by: %s";
        public static String SIGN_TEXT_FORMAT_6 = "Digital signed by: %s \r\nDate: %s";
        public static String SIGN_TEXT_FORMAT_7 = "Digital signed by: %s \r\nDate: %s \r\nReason: %s";
        public static String SIGN_TEXT_FORMAT_8 = "Digital signed by: %s \r\nDate: %s \r\nReason: %s \r\nLocation: %s";
        public static String SIGN_TEXT_FORMAT_9 = "Người Ký: %s\r\n%sNgày ký: %s";
        public static String SIGN_TEXT_FORMAT_10 = "Người Ký: %s\r\n%s\r\n%s\r\nNgày ký: %s";
        public static String FORMAT_RECTANGLE_TEXT_DEFAULT = SIGN_TEXT_FORMAT_2;

        public static String DATE_FORMAT_1 = "HH:mm:ss dd/MM/yyyy";
        public static String DATE_FORMAT_2 = "yyyy/MM/dd HH:mm:ss";

        public static String CONTACT_DEFAULT_EMPTY = "";
        public static String REASON_DEFAULT_EMPTY = "";
        public static String LOCATION_DEFAULT_EMPTY = "";
        public static String ORGANIZATION_UNIT_DEFAULT_EMPTY = "";
        public static String ORGANIZATION_DEFAULT_EMPTY = "";
        public static String DISPLAY_TEXT_DEFAULT_EMPTY = "";
        public static String DATE_FORMAT_STRING_DEFAULT = DATE_FORMAT_1;

        /**
         * End Configuration Display Rectangle
         */
        /**
         * Begin Configuration Display Table
         */
        public static String PAGE_SIZE_DEFAULT = "A4";
        public static int TOTAL_PAGE_SIGN_DEFAULT = 1;
        public static int MAX_PAGE_SIGN_DEFAULT = 10;
        public static String[] TITLES_DEFAULT = new String[] { "STT", "Người Ký", "Đơn vị", "Thời gian ký", "Ý kiến" };
        public static float[] WIDTHS_PERCEN_DEFAULT = new float[] { 0.06f, 0.18f, 0.2f, 0.14f, 0.42f };

        public static float HEIGHT_TITLE_DEFAULT = 30f;
        public static int[] BACKGROUND_COLOR_TITLE_DEFAULT = new int[] { 240, 240, 240 };
        public static int SIZE_FONT_DEFAULT = 11;
        public static float MARGIN_TOP_OF_TABLE_DEFAULT = 80f;
        public static float MARGIN_BOTTOM_OF_TABLE_DEFAULT = 80f;
        public static float MARGIN_RIGHT_OF_TABLE_DEFAULT = 60f;
        public static Boolean IS_DISPLAY_TITLE_PAGE_SIGN_DEFAULT = true;
        public static String TITLE_PAGE_SIGN_DEFAULT = "TRANG KÝ";
        public static float HEIGHT_ROW_TITLE_PAGE_SIGN_DEFAULT = 40f;
        public static int FONT_SIZE_TITLE_PAGE_SIGN_DEFAULT = 15;

        public static int ALIGN_UNDEFINED = -1;
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;
        public static int ALIGN_JUSTIFIED = 3;
        public static int ALIGN_TOP = 4;
        public static int ALIGN_MIDDLE = 5;
        public static int ALIGN_BOTTOM = 6;
        public static int ALIGN_BASELINE = 7;
        public static int ALIGN_JUSTIFIED_ALL = 8;

        public static int[] ALIGNMENT_ARRAY_DEFAULT = new int[] { ALIGN_CENTER, ALIGN_LEFT, ALIGN_JUSTIFIED, ALIGN_LEFT, ALIGN_JUSTIFIED };

        public static String FONT_PATH_TIMESNEWROMAN_WINDOWS = "C:/windows/fonts/times.ttf";
        public static String FONT_PATH_TAHOMA_WINDOWS = "C:/windows/fonts/tahoma.ttf";
        public static String FONT_PATH_ARIAL_WINDOWS = "C:/windows/fonts/arial.ttf";

        //font text of table
        public static String FONT_PATH_DEFAULT = FONT_PATH_TIMESNEWROMAN_WINDOWS;
    }
}