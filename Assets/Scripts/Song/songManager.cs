using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class songManager
{
    //싱글톤
    private static songManager instance = null;

    public static songManager Instance{
        get {
            if(instance == null){
                instance = new songManager();
            }

            return instance;
        }
    }

    public Song[] song;

    public void Init()
    {
        // 각 곡과 난이도에 맞는 채보 저장
        Note[] High1Normal4 = new Note[]{
            new Note("longNote", "1.0", "(300,300,0)", "0", "false", "1.0"),
            new Note("normalNote", "2.1", "(700,700,0)", "1", "false", ""),
            new Note("normalNote", "2.11", "(800,800,0)", "2", "false", ""),
            new Note("normalNote", "2.12", "(600,600,0)", "3", "false", ""),
            new Note("normalNote", "2.13", "(500,500,0)", "4", "false", ""),
            new Note("normalNote", "2.14", "(400,400,0)", "5", "false", ""),
            new Note("normalNote", "2.15", "(300,300,0)", "6", "false", ""),
            new Note("longNote", "5.0", "(600,600,0)", "7", "false", "5.0")
        };

        Note[] High1Hard6 = new Note[]{
            new Note("normalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("longNote", "2.0", "(700,700,0)", "1", "false", "2.0"),
            new Note("normalNote", "5.0", "(600,600,0)", "2", "false", "")
        };

        Note[] High1Death10 = new Note[]{
            new Note("normalNote", "1.0", "(0,300,0)", "0", "false", ""),
            new Note("smallNormalNote", "2.0", "(1920,300,0)", "1", "false", ""),
            new Note("slideNote", "3.0", "(100,500,0)", "2", "false", ""),
            new Note("slideNote", "4.0", "(500,500,0)", "3", "false", ""),
            new Note("longNote", "5.0", "(600,500,0)", "4", "false", "1.0"),
            new Note("bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""),
            new Note("normalNote", "7.0", "(800,200,0)", "6", "false", ""),
            new Note("normalNote", "9.0", "(900,200,0)", "7", "true", ""),
            new Note("normalNote", "10.0", "(700,400,0)", "9", "false", ""),
            new Note("slideNote", "11.0", "(800,500,0)", "10", "false", ""),
            new Note("slideNote", "11.1", "(900,600,0)", "11", "false", ""),
            new Note("slideNote", "11.2", "(1000,700,0)", "12", "false", "")
        };

        Note[] TheLight1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(960,540,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(960,-540,0)", "1", "false", ""),
            new Note("slideNote", "3.0", "(-960,540,0)", "2", "false", ""),
            new Note("slideNote", "4.0", "(-960,-540,0)", "3", "false", "")
        };

        Note[] TheLight1Hard3 = new Note[]{
            new Note("smallNormalNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("bigNormalNote", "5.0", "(600,600,0)", "1", "false", ""),
            new Note("normalNote", "6.0", "(800,800,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", ""),
            new Note("normalNote", "8.0", "(800,600,0)", "4", "false", "")
        };

        Note[] TheLight1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] TooHotToHandle1Normal1 = new Note[]{
            
        };

        Note[] TooHotToHandle1Hard5 = new Note[]{
            new Note("longNote","4.41","(1,-3,0)","0","false","2.0"),
            new Note("longNote","7.52","(4,0,0)","1","false","2.0"),
            new Note("longNote","10.92","(1,2,0)","2","false","2.0"),
            new Note("longNote","15.26","(-535,-3,0)","3","true","2.0"),
            new Note("longNote","15.26","(529,-1,0)","4","true","2.0"),
            new Note("normalNote","19.20","(-481,234,0)","5","false","0.0"),
            new Note("normalNote","19.52","(463,-222,0)","6","false","0.0"),
            new Note("smallNormalNote","19.84","(-511,-222,0)","7","true","0.0"),
            new Note("smallNormalNote","19.84","(519,240,0)","8","true","0.0"),
            new Note("smallNormalNote","20.21","(-518,213,0)","9","true","0.0"),
            new Note("smallNormalNote","20.21","(538,-235,0)","10","true","0.0"),
            new Note("slideNote","20.57","(654,274,0)","11","true","0.0"),
            new Note("slideNote","20.57","(-654,-289,0)","12","true","0.0"),
            new Note("slideNote","20.84","(-671,-128,0)","13","true","0.0"),
            new Note("slideNote","20.84","(705,125,0)","14","true","0.0"),
            new Note("slideNote","21.13","(-694,4,0)","15","true","0.0"),
            new Note("slideNote","21.13","(695,-1,0)","16","true","0.0"),
            new Note("slideNote","21.34","(-708,148,0)","17","true","0.0"),
            new Note("slideNote","21.34","(737,-166,0)","18","true","0.0"),
            new Note("slideNote","21.62","(-721,298,0)","19","true","0.0"),
            new Note("slideNote","21.62","(753,-305,0)","20","true","0.0"),
            new Note("smallNormalNote","22.89","(-506,-241,0)","21","true","0.0"),
            new Note("smallNormalNote","22.89","(543,244,0)","22","true","0.0"),
            new Note("smallNormalNote","23.23","(-529,224,0)","23","true","0.0"),
            new Note("smallNormalNote","23.23","(537,-227,0)","24","true","0.0"),
            new Note("longNote","23.38","(-511,229,0)","25","false","2.0"),
            new Note("normalNote","23.62","(124,-209,0)","26","false","0.0"),
            new Note("normalNote","23.92","(417,-217,0)","27","false","0.0"),
            new Note("normalNote","24.23","(778,-209,0)","28","false","0.0"),
            new Note("longNote","26.34","(463,-220,0)","29","false","2.0"),
            new Note("normalNote","26.77","(-778,269,0)","30","false","0.0"),
            new Note("normalNote","27.06","(-518,-28,0)","31","false","0.0"),
            new Note("normalNote","27.36","(-137,-312,0)","32","false","0.0"),
            new Note("slideNote","27.75","(-786,-1,0)","33","false","0.0"),
            new Note("slideNote","27.93","(-636,-3,0)","34","false","0.0"),
            new Note("slideNote","28.21","(-380,0,0)","35","false","0.0"),
            new Note("slideNote","28.48","(-178,0,0)","36","false","0.0"),
            new Note("slideNote","30.06","(750,296,0)","37","false","0.0"),
            new Note("slideNote","30.28","(671,168,0)","38","false","0.0"),
            new Note("slideNote","30.53","(574,37,0)","39","false","0.0"),
            new Note("slideNote","30.74","(444,-73,0)","40","false","0.0"),
            new Note("slideNote","30.97","(316,-224,0)","41","false","0.0"),
            new Note("slideNote","31.18","(130,-312,0)","42","false","0.0"),
            new Note("bigNormalNote","31.20","(-538,0,0)","43","false","0.0"),
            new Note("smallNormalNote","31.53","(126,-104,0)","44","false","0.0"),
            new Note("smallNormalNote","31.77","(834,-348,0)","45","false","0.0"),
            new Note("smallNormalNote","32.04","(858,96,0)","46","false","0.0"),
            new Note("smallNormalNote","32.34","(92,359,0)","47","false","0.0"),
            new Note("longNote","32.96","(-630,231,0)","48","false","2.0"),
            new Note("longNote","33.43","(516,-217,0)","49","false","2.0"),
            new Note("longNote","35.84","(-210,-216,0)","50","false","2.0"),
            new Note("slideNote","36.18","(129,309,0)","51","false","0.0"),
            new Note("slideNote","36.41","(236,112,0)","52","false","0.0"),
            new Note("slideNote","36.63","(354,-49,0)","53","false","0.0"),
            new Note("slideNote","36.86","(487,-222,0)","54","false","0.0"),
            new Note("slideNote","37.13","(682,-324,0)","55","false","0.0"),
            new Note("bigNormalNote","37.45","(729,234,0)","56","false","0.0"),
            new Note("smallNormalNote","37.84","(-855,344,0)","57","false","0.0"),
            new Note("smallNormalNote","38.13","(-740,103,0)","58","false","0.0"),
            new Note("smallNormalNote","38.45","(-596,-140,0)","59","false","0.0"),
            new Note("smallNormalNote","38.72","(-418,-342,0)","60","false","0.0"),
            new Note("smallNormalNote","38.98","(-238,-123,0)","61","false","0.0"),
            new Note("smallNormalNote","39.23","(-68,-6,0)","62","false","0.0"),
            new Note("smallNormalNote","39.52","(86,178,0)","63","false","0.0"),
            new Note("slideNote","39.75","(369,304,0)","64","false","0.0"),
            new Note("slideNote","40.02","(335,143,0)","65","false","0.0"),
            new Note("slideNote","40.10","(334,31,0)","66","false","0.0"),
            new Note("slideNote","40.34","(332,-41,0)","67","false","0.0"),
            new Note("longNote","40.54","(321,-246,0)","68","false","2.0"),
            new Note("normalNote","40.92","(-814,309,0)","69","false","0.0"),
            new Note("slideNote","41.16","(-562,312,0)","70","false","0.0"),
            new Note("slideNote","41.37","(-473,303,0)","71","false","0.0"),
            new Note("slideNote","41.61","(-367,298,0)","72","false","0.0"),
            new Note("slideNote","41.79","(-278,309,0)","73","false","0.0"),
            new Note("slideNote","42.02","(-154,309,0)","74","false","0.0"),
            new Note("slideNote","42.22","(-151,208,0)","75","false","0.0"),
            new Note("slideNote","42.42","(-140,68,0)","76","false","0.0"),
            new Note("longNote","42.75","(727,242,0)","77","false","2.0"),
            new Note("longNote","42.83","(-185,-240,0)","78","false","2.0"),
            new Note("normalNote","45.27","(-764,295,0)","79","true","0.0"),
            new Note("normalNote","45.27","(801,-297,0)","80","true","0.0"),
            new Note("normalNote","45.47","(-553,124,0)","81","true","0.0"),
            new Note("normalNote","45.47","(628,-126,0)","82","true","0.0"),
            new Note("normalNote","45.70","(-354,-1,0)","83","true","0.0"),
            new Note("normalNote","45.70","(377,-1,0)","84","true","0.0"),
            new Note("bigNormalNote","46.01","(1,0,0)","85","false","0.0"),
            new Note("slideNote","46.28","(-777,308,0)","86","false","0.0"),
            new Note("slideNote","46.52","(-628,303,0)","87","false","0.0"),
            new Note("slideNote","46.71","(-449,303,0)","88","false","0.0"),
            new Note("slideNote","46.93","(-252,303,0)","89","false","0.0"),
            new Note("longNote","47.07","(252,221,0)","90","false","2.0"),
            new Note("slideNote","47.16","(-63,309,0)","91","false","0.0"),
            new Note("slideNote","47.46","(-825,309,0)","92","false","0.0"),
            new Note("slideNote","47.69","(-820,210,0)","93","false","0.0"),
            new Note("slideNote","47.93","(-830,68,0)","94","false","0.0"),
            new Note("slideNote","48.16","(-839,-40,0)","95","false","0.0"),
            new Note("slideNote","48.42","(-831,-148,0)","96","false","0.0"),
            new Note("slideNote","48.67","(-822,-283,0)","97","false","0.0"),
            new Note("longNote","52.60","(1,2,0)","98","false","2.0"),
            new Note("longNote","56.79","(-1,-3,0)","99","false","2.0"),
            new Note("longNote","60.56","(-1,-3,0)","100","false","2.0"),
            new Note("longNote","64.20","(-498,-3,0)","101","true","2.0"),
            new Note("longNote","64.20","(545,0,0)","102","true","2.0"),
            new Note("longNote","67.79","(-546,4,0)","103","true","2.0"),
            new Note("slideNote","67.79","(455,314,0)","104","true","0.0"),
            new Note("slideNote","68.03","(297,252,0)","105","false","0.0"),
            new Note("slideNote","68.20","(207,181,0)","106","false","0.0"),
            new Note("slideNote","68.40","(162,58,0)","107","false","0.0"),
            new Note("slideNote","68.58","(97,-6,0)","108","false","0.0"),
            new Note("slideNote","68.72","(198,-118,0)","109","false","0.0"),
            new Note("slideNote","68.87","(314,-224,0)","110","false","0.0"),
            new Note("slideNote","69.07","(442,-320,0)","111","false","0.0"),
            new Note("longNote","71.58","(-561,-3,0)","112","true","2.0"),
            new Note("slideNote","71.58","(462,-312,0)","113","true","0.0"),
            new Note("slideNote","71.75","(537,-230,0)","114","false","0.0"),
            new Note("slideNote","71.93","(695,-144,0)","115","false","0.0"),
            new Note("slideNote","72.11","(783,-25,0)","116","false","0.0"),
            new Note("slideNote","72.29","(711,124,0)","117","false","0.0"),
            new Note("slideNote","72.47","(610,228,0)","118","false","0.0"),
            new Note("slideNote","72.63","(554,282,0)","119","false","0.0"),
            new Note("slideNote","72.81","(513,314,0)","120","false","0.0"),
            new Note("longNote","75.34","(-2,-1,0)","121","false","2.0"),
            new Note("longNote","79.08","(558,226,0)","122","false","2.0"),
            new Note("longNote","83.35","(543,-211,0)","123","false","2.0"),
            new Note("slideNote","86.85","(-786,293,0)","124","true","0.0"),
            new Note("slideNote","86.85","(785,301,0)","125","true","0.0"),
            new Note("slideNote","87.08","(-729,199,0)","126","true","0.0"),
            new Note("slideNote","87.08","(767,223,0)","127","true","0.0"),
            new Note("slideNote","87.29","(-636,112,0)","128","true","0.0"),
            new Note("slideNote","87.29","(686,112,0)","129","true","0.0"),
            new Note("slideNote","87.45","(-551,10,0)","130","true","0.0"),
            new Note("slideNote","87.45","(588,-3,0)","131","true","0.0"),
            new Note("slideNote","87.62","(-436,-84,0)","132","true","0.0"),
            new Note("slideNote","87.62","(558,-67,0)","133","true","0.0"),
            new Note("slideNote","87.86","(-337,-177,0)","134","true","0.0"),
            new Note("slideNote","87.86","(430,-163,0)","135","true","0.0"),
            new Note("slideNote","88.02","(-151,-256,0)","136","true","0.0"),
            new Note("slideNote","88.02","(268,-256,0)","137","true","0.0"),
            new Note("slideNote","88.39","(-826,309,0)","138","true","0.0"),
            new Note("slideNote","88.39","(810,-296,0)","139","true","0.0"),
            new Note("slideNote","88.57","(-726,226,0)","140","true","0.0"),
            new Note("slideNote","88.57","(748,-228,0)","141","true","0.0"),
            new Note("slideNote","88.74","(-631,146,0)","142","true","0.0"),
            new Note("slideNote","88.74","(636,-163,0)","143","true","0.0"),
            new Note("slideNote","88.96","(-521,44,0)","144","true","0.0"),
            new Note("slideNote","88.96","(546,-62,0)","145","true","0.0"),
            new Note("slideNote","89.13","(-425,-52,0)","146","true","0.0"),
            new Note("slideNote","89.13","(449,44,0)","147","true","0.0"),
            new Note("slideNote","89.32","(-302,-140,0)","148","true","0.0"),
            new Note("slideNote","89.32","(345,128,0)","149","true","0.0"),
            new Note("slideNote","89.51","(-215,-216,0)","150","true","0.0"),
            new Note("slideNote","89.51","(300,242,0)","151","true","0.0"),
            new Note("slideNote","89.67","(-97,-305,0)","152","true","0.0"),
            new Note("slideNote","89.67","(129,306,0)","153","true","0.0"),
            new Note("slideNote","90.15","(-118,312,0)","154","true","0.0"),
            new Note("slideNote","90.15","(796,309,0)","155","true","0.0"),
            new Note("slideNote","90.34","(-202,204,0)","156","true","0.0"),
            new Note("slideNote","90.34","(721,199,0)","157","true","0.0"),
            new Note("slideNote","90.50","(-286,116,0)","158","true","0.0"),
            new Note("slideNote","90.50","(686,108,0)","159","true","0.0"),
            new Note("slideNote","90.66","(-364,21,0)","160","true","0.0"),
            new Note("slideNote","90.66","(642,44,0)","161","true","0.0"),
            new Note("slideNote","90.83","(-474,-60,0)","162","true","0.0"),
            new Note("slideNote","90.83","(583,-41,0)","163","true","0.0"),
            new Note("slideNote","90.96","(-550,-139,0)","164","true","0.0"),
            new Note("slideNote","90.96","(535,-139,0)","165","true","0.0"),
            new Note("slideNote","91.13","(-622,-206,0)","166","true","0.0"),
            new Note("slideNote","91.13","(433,-187,0)","167","true","0.0"),
            new Note("slideNote","91.28","(-703,-288,0)","168","true","0.0"),
            new Note("slideNote","91.28","(330,-299,0)","169","true","0.0"),
            new Note("normalNote","91.53","(-737,276,0)","170","true","0.0"),
            new Note("normalNote","91.53","(772,-233,0)","171","true","0.0"),
            new Note("normalNote","91.77","(-466,282,0)","172","true","0.0"),
            new Note("normalNote","91.77","(401,-190,0)","173","true","0.0"),
            new Note("normalNote","91.94","(-122,284,0)","174","true","0.0"),
            new Note("normalNote","91.94","(801,287,0)","175","true","0.0"),
            new Note("normalNote","92.16","(-334,127,0)","176","true","0.0"),
            new Note("normalNote","92.16","(636,128,0)","177","true","0.0"),
            new Note("normalNote","92.51","(-436,0,0)","178","true","0.0"),
            new Note("normalNote","92.51","(550,0,0)","179","true","0.0"),
            new Note("longNote","92.87","(-654,-1,0)","180","true","2.0"),
            new Note("smallNormalNote","92.87","(132,324,0)","181","true","0.0"),
            new Note("smallNormalNote","93.14","(362,317,0)","182","false","0.0"),
            new Note("smallNormalNote","93.41","(367,98,0)","183","false","0.0"),
            new Note("smallNormalNote","93.64","(362,-99,0)","184","false","0.0"),
            new Note("smallNormalNote","93.85","(370,-300,0)","185","false","0.0"),
            new Note("smallNormalNote","94.02","(527,-344,0)","186","false","0.0"),
            new Note("smallNormalNote","94.21","(847,-339,0)","187","false","0.0"),
            new Note("smallNormalNote","94.51","(833,-91,0)","188","false","0.0"),
            new Note("slideNote","97.31","(759,-4,0)","189","false","0.0"),
            new Note("slideNote","97.50","(630,-1,0)","190","false","0.0"),
            new Note("slideNote","97.66","(484,-3,0)","191","false","0.0"),
            new Note("slideNote","97.84","(342,2,0)","192","false","0.0"),
            new Note("slideNote","98.00","(204,-1,0)","193","false","0.0"),
            new Note("slideNote","98.16","(86,-1,0)","194","false","0.0"),
            new Note("slideNote","98.32","(-26,-3,0)","195","false","0.0"),
            new Note("slideNote","98.49","(-143,-1,0)","196","false","0.0"),
            new Note("slideNote","98.66","(-242,-4,0)","197","false","0.0"),
            new Note("slideNote","98.82","(-353,-1,0)","198","false","0.0"),
            new Note("slideNote","99.00","(-458,-1,0)","199","false","0.0"),
            new Note("slideNote","99.19","(-596,2,0)","200","false","0.0"),
            new Note("normalNote","101.43","(-527,253,0)","201","true","0.0"),
            new Note("normalNote","101.43","(532,-211,0)","202","true","0.0"),
            new Note("smallNormalNote","101.73","(-700,-225,0)","203","true","0.0"),
            new Note("smallNormalNote","101.73","(759,239,0)","204","true","0.0"),
            new Note("smallNormalNote","101.98","(-178,-216,0)","205","true","0.0"),
            new Note("smallNormalNote","101.98","(201,221,0)","206","true","0.0"),
            new Note("bigNormalNote","102.21","(-566,232,0)","207","true","0.0"),
            new Note("normalNote","102.21","(126,-4,0)","208","true","0.0"),
            new Note("normalNote","102.50","(466,-3,0)","209","false","0.0"),
            new Note("normalNote","102.71","(822,-4,0)","210","false","0.0"),
            new Note("normalNote","103.41","(-137,-1,0)","211","false","0.0"),
            new Note("normalNote","103.65","(-399,-1,0)","212","false","0.0"),
            new Note("normalNote","103.98","(-673,0,0)","213","false","0.0"),
            new Note("longNote","104.24","(713,0,0)","214","false","2.0"),
            new Note("longNote","105.37","(-647,0,0)","215","false","2.0"),
            new Note("slideNote","108.72","(-745,300,0)","216","true","0.0"),
            new Note("slideNote","108.72","(750,-294,0)","217","true","0.0"),
            new Note("slideNote","108.90","(-738,156,0)","218","true","0.0"),
            new Note("slideNote","108.90","(762,-184,0)","219","true","0.0"),
            new Note("slideNote","109.05","(-716,0,0)","220","true","0.0"),
            new Note("slideNote","109.05","(737,-4,0)","221","true","0.0"),
            new Note("slideNote","109.22","(-722,-145,0)","222","true","0.0"),
            new Note("slideNote","109.22","(729,140,0)","223","true","0.0"),
            new Note("slideNote","109.42","(-718,-284,0)","224","true","0.0"),
            new Note("slideNote","109.42","(735,284,0)","225","true","0.0"),
            new Note("slideNote","109.63","(-404,-294,0)","226","true","0.0"),
            new Note("slideNote","109.63","(450,-300,0)","227","true","0.0"),
            new Note("slideNote","109.86","(-425,-211,0)","228","true","0.0"),
            new Note("slideNote","109.86","(420,-195,0)","229","true","0.0"),
            new Note("slideNote","110.03","(-414,-126,0)","230","true","0.0"),
            new Note("slideNote","110.03","(406,-107,0)","231","true","0.0"),
            new Note("slideNote","110.18","(-409,-33,0)","232","true","0.0"),
            new Note("slideNote","110.18","(374,-25,0)","233","true","0.0"),
            new Note("slideNote","110.35","(-425,34,0)","234","true","0.0"),
            new Note("slideNote","110.35","(372,47,0)","235","true","0.0"),
            new Note("slideNote","110.60","(-428,119,0)","236","true","0.0"),
            new Note("slideNote","110.60","(330,124,0)","237","true","0.0"),
            new Note("slideNote","110.75","(-420,220,0)","238","true","0.0"),
            new Note("slideNote","110.75","(362,218,0)","239","true","0.0"),
            new Note("normalNote","112.55","(-700,287,0)","240","true","0.0"),
            new Note("normalNote","112.55","(708,295,0)","241","true","0.0"),
            new Note("normalNote","113.24","(-682,-283,0)","242","true","0.0"),
            new Note("normalNote","113.24","(636,-297,0)","243","true","0.0"),
            new Note("normalNote","113.67","(-658,5,0)","244","true","0.0"),
            new Note("normalNote","113.67","(663,0,0)","245","true","0.0"),
            new Note("normalNote","114.06","(-4,300,0)","246","true","0.0"),
            new Note("normalNote","114.06","(-2,-275,0)","247","true","0.0"),
            new Note("smallNormalNote","116.63","(-794,325,0)","248","true","0.0"),
            new Note("smallNormalNote","116.63","(844,344,0)","249","true","0.0"),
            new Note("smallNormalNote","117.03","(-494,4,0)","250","true","0.0"),
            new Note("smallNormalNote","117.03","(545,-1,0)","251","true","0.0"),
            new Note("smallNormalNote","117.53","(-830,346,0)","252","true","0.0"),
            new Note("smallNormalNote","117.53","(817,351,0)","253","true","0.0"),
            new Note("slideNote","120.12","(-756,4,0)","254","false","0.0"),
            new Note("slideNote","120.33","(-646,-3,0)","255","false","0.0"),
            new Note("slideNote","120.54","(-529,2,0)","256","false","0.0"),
            new Note("slideNote","120.78","(-402,-4,0)","257","false","0.0"),
            new Note("slideNote","120.99","(-287,-1,0)","258","false","0.0"),
            new Note("slideNote","121.24","(-178,-6,0)","259","false","0.0"),
            new Note("slideNote","121.44","(-63,-4,0)","260","false","0.0"),
            new Note("slideNote","121.68","(79,-1,0)","261","false","0.0"),
            new Note("slideNote","121.85","(231,0,0)","262","false","0.0"),
            new Note("slideNote","122.13","(382,-3,0)","263","false","0.0"),
            new Note("slideNote","122.34","(519,4,0)","264","false","0.0"),
            new Note("longNote","122.63","(746,-1,0)","265","false","2.0"),
            new Note("bigNormalNote","124.06","(-583,-3,0)","266","false","0.0"),
            new Note("normalNote","124.42","(-159,-1,0)","267","false","0.0"),
            new Note("bigNormalNote","125.06","(503,0,0)","268","false","0.0"),
            new Note("longNote","125.26","(-678,-4,0)","269","false","2.0"),
            new Note("smallNormalNote","125.39","(134,0,0)","270","false","0.0"),
            new Note("smallNormalNote","125.75","(495,-284,0)","271","false","0.0"),
            new Note("smallNormalNote","126.15","(494,282,0)","272","false","0.0"),
            new Note("normalNote","127.00","(519,0,0)","273","false","0.0"),
            new Note("normalNote","127.45","(-521,234,0)","274","true","0.0"),
            new Note("normalNote","127.45","(470,-217,0)","275","true","0.0"),
            new Note("normalNote","127.79","(-514,-219,0)","276","true","0.0"),
            new Note("normalNote","127.79","(516,240,0)","277","true","0.0"),
            new Note("normalNote","128.32","(-583,0,0)","278","true","0.0"),
            new Note("normalNote","128.32","(569,-1,0)","279","true","0.0"),
            new Note("bigNormalNote","128.79","(-1,-3,0)","280","false","0.0")
        };

        Note[] TooHotToHandle1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] YouDidMeWrong1Normal5 = new Note[]{
            new Note("normalNote","2.56","(-540,192,0)","0","false","0.0"),
            new Note("normalNote","2.80","(-447,-164,0)","1","false","0.0"),
            new Note("normalNote","3.02","(87,184,0)","2","false","0.0"),
            new Note("normalNote","3.31","(345,-211,0)","3","false","0.0"),
            new Note("normalNote","3.61","(698,234,0)","4","false","0.0"),
            new Note("normalNote","6.26","(-644,152,0)","5","false","0.0"),
            new Note("normalNote","6.54","(-462,-123,0)","6","false","0.0"),
            new Note("normalNote","6.88","(-41,122,0)","7","false","0.0"),
            new Note("normalNote","7.31","(225,-216,0)","8","false","0.0"),
            new Note("normalNote","7.79","(642,79,0)","9","false","0.0"),
            new Note("normalNote","9.18","(-617,301,0)","10","false","0.0"),
            new Note("normalNote","9.65","(-158,-11,0)","11","false","0.0"),
            new Note("normalNote","10.49","(618,-281,0)","12","false","0.0"),
            new Note("normalNote","13.23","(686,316,0)","13","false","0.0"),
            new Note("normalNote","13.88","(-28,-54,0)","14","false","0.0"),
            new Note("normalNote","14.58","(-601,-293,0)","15","false","0.0"),
            new Note("longNote","16.68","(-575,8,0)","16","false","2.0"),
            new Note("longNote","20.12","(706,-4,0)","17","false","2.0"),
            new Note("slideNote","25.49","(-516,202,0)","18","false","0.0"),
            new Note("slideNote","26.14","(28,199,0)","19","false","0.0"),
            new Note("slideNote","26.89","(729,192,0)","20","false","0.0"),
            new Note("slideNote","27.66","(684,-295,0)","21","false","0.0"),
            new Note("slideNote","28.31","(1,-299,0)","22","false","0.0"),
            new Note("slideNote","29.02","(-562,-295,0)","23","false","0.0"),
            new Note("normalNote","31.27","(-638,15,0)","24","false","0.0"),
            new Note("normalNote","31.56","(-688,15,0)","25","false","0.0"),
            new Note("normalNote","31.73","(-738,15,0)","26","false","0.0"),
            new Note("normalNote","31.98","(-788,15,0)","27","false","0.0"),
            new Note("normalNote","32.12","(-838,15,0)","28","false","0.0"),
            new Note("normalNote","32.55","(486,24,0)","29","false","0.0"),
            new Note("normalNote","33.05","(-802,-17,0)","30","false","0.0"),
            new Note("normalNote","34.74","(574,-1,0)","31","false","0.0"),
            new Note("normalNote","35.16","(574,-1,0)","32","false","0.0"),
            new Note("normalNote","35.37","(574,-1,0)","33","false","0.0"),
            new Note("normalNote","35.59","(574,-1,0)","34","false","0.0"),
            new Note("normalNote","35.75","(574,-1,0)","35","false","0.0"),
            new Note("normalNote","36.23","(-708,-4,0)","36","false","0.0"),
            new Note("normalNote","37.05","(663,10,0)","37","false","0.0"),
            new Note("normalNote","38.14","(-270,232,0)","38","false","0.0"),
            new Note("normalNote","38.75","(-252,-209,0)","39","false","0.0"),
            new Note("normalNote","39.19","(311,-220,0)","40","false","0.0"),
            new Note("normalNote","39.68","(327,236,0)","41","false","0.0"),
            new Note("normalNote","40.12","(327,236,0)","42","false","0.0"),
            new Note("normalNote","40.62","(318,-299,0)","43","false","0.0"),
            new Note("normalNote","41.10","(-369,-228,0)","44","false","0.0"),
            new Note("normalNote","41.51","(-313,248,0)","45","false","0.0"),
            new Note("slideNote","42.27","(-577,260,0)","46","false","0.0"),
            new Note("slideNote","42.60","(-226,-168,0)","47","false","0.0"),
            new Note("slideNote","42.90","(-81,-168,0)","48","false","0.0"),
            new Note("slideNote","43.33","(69,-171,0)","49","false","0.0"),
            new Note("slideNote","43.50","(247,-167,0)","50","false","0.0"),
            new Note("slideNote","44.20","(539,270,0)","51","false","0.0"),
            new Note("slideNote","45.88","(684,4,0)","52","false","0.0"),
            new Note("slideNote","46.86","(218,300,0)","53","false","0.0"),
            new Note("slideNote","47.22","(-57,300,0)","54","false","0.0"),
            new Note("slideNote","47.72","(-250,328,0)","55","false","0.0"),
            new Note("slideNote","48.21","(-550,290,0)","56","false","0.0"),
            new Note("slideNote","48.94","(-711,-51,0)","57","false","0.0"),
            new Note("longNote","51.34","(662,-1,0)","58","false","2.0"),
            new Note("smallNormalNote","51.89","(-508,215,0)","59","false","0.0"),
            new Note("smallNormalNote","52.42","(-474,-32,0)","60","false","0.0"),
            new Note("smallNormalNote","52.85","(-506,-264,0)","61","false","0.0"),
            new Note("longNote","54.59","(-569,-3,0)","62","false","2.0"),
            new Note("smallNormalNote","55.04","(481,255,0)","63","false","0.0"),
            new Note("smallNormalNote","55.57","(508,-22,0)","64","false","0.0"),
            new Note("smallNormalNote","56.09","(542,-347,0)","65","false","0.0"),
            new Note("normalNote","60.81","(-617,2,0)","66","true","0.0"),
            new Note("normalNote","60.81","(642,-3,0)","67","true","0.0"),
            new Note("normalNote","61.33","(-636,-1,0)","68","true","0.0"),
            new Note("normalNote","61.33","(626,-3,0)","69","true","0.0"),
            new Note("normalNote","63.71","(-631,5,0)","70","true","0.0"),
            new Note("normalNote","63.71","(663,-3,0)","71","true","0.0"),
            new Note("normalNote","64.21","(-654,0,0)","72","true","0.0"),
            new Note("normalNote","64.21","(663,-3,0)","73","true","0.0"),
            new Note("bigNormalNote","65.76","(-2,-3,0)","74","false","0.0"),
            new Note("slideNote","67.29","(-546,194,0)","75","false","0.0"),
            new Note("slideNote","67.61","(-442,28,0)","76","false","0.0"),
            new Note("slideNote","67.95","(-215,-198,0)","77","false","0.0"),
            new Note("slideNote","68.33","(81,-305,0)","78","false","0.0"),
            new Note("slideNote","68.73","(402,-275,0)","79","false","0.0"),
            new Note("slideNote","69.13","(575,-68,0)","80","false","0.0"),
            new Note("slideNote","69.63","(721,304,0)","81","false","0.0"),
            new Note("slideNote","71.59","(591,208,0)","82","false","0.0"),
            new Note("slideNote","72.04","(458,-67,0)","83","false","0.0"),
            new Note("slideNote","72.38","(239,-240,0)","84","false","0.0"),
            new Note("slideNote","72.95","(-110,-251,0)","85","false","0.0"),
            new Note("slideNote","73.39","(-404,-179,0)","86","false","0.0"),
            new Note("slideNote","73.97","(-684,271,0)","87","false","0.0"),
            new Note("normalNote","74.98","(247,200,0)","88","false","0.0"),
            new Note("longNote","74.99","(-516,0,0)","89","false","2.0"),
            new Note("normalNote","75.32","(246,199,0)","90","false","0.0"),
            new Note("normalNote","75.77","(719,-257,0)","91","false","0.0"),
            new Note("normalNote","76.14","(719,-279,0)","92","false","0.0"),
            new Note("slideNote","78.20","(502,311,0)","93","false","0.0"),
            new Note("slideNote","78.73","(518,10,0)","94","false","0.0"),
            new Note("slideNote","79.30","(519,-286,0)","95","false","0.0"),
            new Note("longNote","80.41","(-558,-3,0)","96","false","2.0"),
            new Note("normalNote","80.97","(657,248,0)","97","false","0.0"),
            new Note("normalNote","81.50","(250,-300,0)","98","false","0.0"),
            new Note("slideNote","84.73","(-529,296,0)","99","false","0.0"),
            new Note("slideNote","85.37","(-537,-6,0)","100","false","0.0"),
            new Note("slideNote","86.36","(-546,-288,0)","101","false","0.0"),
            new Note("longNote","89.49","(460,4,0)","102","false","2.0"),
            new Note("normalNote","91.09","(-529,264,0)","103","false","0.0"),
            new Note("normalNote","91.66","(-183,-116,0)","104","false","0.0"),
            new Note("normalNote","92.12","(-658,-256,0)","105","false","0.0"),
            new Note("normalNote","92.55","(-831,156,0)","106","false","0.0"),
            new Note("bigNormalNote","93.24","(498,0,0)","107","false","0.0"),
            new Note("smallNormalNote","94.56","(-254,311,0)","108","false","0.0"),
            new Note("smallNormalNote","95.05","(-767,263,0)","109","false","0.0"),
            new Note("smallNormalNote","95.55","(-745,-243,0)","110","false","0.0"),
            new Note("smallNormalNote","96.15","(-182,-246,0)","111","false","0.0"),
            new Note("slideNote","96.92","(193,-291,0)","112","false","0.0"),
            new Note("slideNote","97.26","(473,4,0)","113","false","0.0"),
            new Note("slideNote","97.68","(767,308,0)","114","false","0.0"),
            new Note("slideNote","99.84","(-806,309,0)","115","false","0.0"),
            new Note("slideNote","99.98","(-654,96,0)","116","false","0.0"),
            new Note("slideNote","100.45","(-490,-121,0)","117","false","0.0"),
            new Note("slideNote","100.94","(-214,-310,0)","118","false","0.0"),
            new Note("slideNote","102.11","(150,292,0)","119","false","0.0"),
            new Note("slideNote","102.47","(318,116,0)","120","false","0.0"),
            new Note("slideNote","102.77","(535,-72,0)","121","false","0.0"),
            new Note("slideNote","103.14","(772,-275,0)","122","false","0.0"),
            new Note("normalNote","104.73","(-502,4,0)","123","false","0.0"),
            new Note("longNote","105.62","(457,-3,0)","124","false","2.0"),
            new Note("normalNote","106.28","(-156,290,0)","125","false","0.0"),
            new Note("normalNote","106.86","(-457,-9,0)","126","false","0.0"),
            new Note("normalNote","107.57","(-762,-278,0)","127","false","0.0"),
            new Note("normalNote","109.15","(-710,295,0)","128","false","0.0"),
            new Note("normalNote","109.70","(-359,-280,0)","129","false","0.0"),
            new Note("normalNote","110.33","(-10,280,0)","130","false","0.0"),
            new Note("normalNote","110.99","(516,-256,0)","131","false","0.0"),
            new Note("normalNote","111.75","(788,285,0)","132","false","0.0"),
            new Note("longNote","112.84","(1,-1,0)","133","false","2.0"),
            new Note("smallNormalNote","115.23","(-521,236,0)","134","false","0.0"),
            new Note("smallNormalNote","115.48","(-535,231,0)","135","false","0.0"),
            new Note("smallNormalNote","115.84","(511,-230,0)","136","false","0.0"),
            new Note("smallNormalNote","116.11","(505,-225,0)","137","false","0.0"),
            new Note("slideNote","116.87","(-566,2,0)","138","false","0.0"),
            new Note("slideNote","117.28","(-1,-3,0)","139","false","0.0"),
            new Note("slideNote","117.86","(569,0,0)","140","false","0.0")
        };

        Note[] YouDidMeWrong1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] YouDidMeWrong1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] ADayatSea1Normal1 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] ADayatSea1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] ADayatSea1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Muffin1Normal1 = new Note[]{
            new Note("smallNormalNote","1.00","(-454,186,0)","0","false","0.0"),
            new Note("smallNormalNote","1.36","(-454,186,0)","1","false","0.0"),
            new Note("normalNote","2.11","(-90,213,0)","2","false","0.0"),
            new Note("bigNormalNote","3.38","(574,136,0)","3","false","0.0"),
            new Note("slideNote","4.70","(-690,-69,0)","4","false","0.0"),
            new Note("slideNote","5.49","(-180,-92,0)","5","false","0.0"),
            new Note("slideNote","6.16","(499,-142,0)","6","false","0.0"),
            new Note("longNote","7.79","(-655,268,0)","7","false","2.0"),
            new Note("longNote","10.11","(49,329,0)","8","false","2.0"),
            new Note("longNote","12.44","(508,-62,0)","9","false","2.0"),
            new Note("longNote","14.81","(-537,-219,0)","10","false","5.0")
        };

        Note[] Muffin1Hard3 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };

        Note[] Muffin1Death5 = new Note[]{
            new Note("slideNote", "1.0", "(300,300,0)", "0", "false", ""),
            new Note("slideNote", "2.0", "(700,700,0)", "1", "false", ""),
            new Note("slideNote", "5.0", "(600,600,0)", "2", "false", ""),
            new Note("slideNote", "7.0", "(600,600,0)", "3", "false", "")
        };


        song = new Song[]{
            new Song("0", "High", "JPB", 4, 6, 10, High1Normal4, High1Hard6, High1Death10),
            new Song("1", "The Light", "Tetrix Bass Feat. Veela", 1, 3, 5, TheLight1Normal1, TheLight1Hard3, TheLight1Death5),
            new Song("2", "Too Hot To Handle", "Fiko & BLUK", 1, 5, 5, TooHotToHandle1Normal1, TooHotToHandle1Hard5, TooHotToHandle1Death5),
            new Song("3", "You Did Me Wrong", "Cajama", 5, 3, 5, YouDidMeWrong1Normal5, YouDidMeWrong1Hard3, YouDidMeWrong1Death5),
            new Song("4", "A Day at Sea", "Everen Maxwell", 1, 3, 5, ADayatSea1Normal1, ADayatSea1Hard3, ADayatSea1Death5),
            new Song("5", "Muffin", "Raven & Kreyn", 1, 3, 5,Muffin1Normal1, Muffin1Hard3, Muffin1Death5)
        };
    }

    // id를 사용하여 곡을 찾는 함수
    public Song getSongbyId(string id){
        Song findsong = null;
        foreach (var songData in song)
        {
            if(songData.id == id) findsong = songData;
        }

        return findsong;
    }

    // 곡 난이도가 포함된 ID를 생성
    public string MakeIdWithDifficulty(string songID, string songDifficulty)
    {
        return songID + "_" + songDifficulty;
    }


    // 로그인 시 로컬 기록과 서버 기록을 비교 후 갱신하는 함수
    public IEnumerator loginPlayRecordUpdate()
    {
        // URL 저장
        Debug.Log(Constants.HOST+ "score/" + AuthManager.Instance.UserId);
        string url = Constants.HOST+ "score/" + AuthManager.Instance.UserId;
        
        // URL에 접속
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if(www.error != null)
        {
            Debug.Log(www.error);
            www.Dispose();
            yield break;
        }
        
        // recordData 배열 안에 서버에 저장되어 있던 기록을 저장
        Debug.Log(www.downloadHandler.text);
        Records recordData = JsonUtility.FromJson<Records>(www.downloadHandler.text);

        // 로그인 시에 서버에 저장되어 있던 기록과 로컬에 저장되어 있던 기록을 비교  
        for(int i = 0; i < song.Length; i++)
        {
            for(int j = 0; j < recordData.records.Length; j++)
            {
                // 서버에 점수 기록이 있음 (서버에 기록이 없다면 아무 일도 일어나지 않음)
                if(MakeIdWithDifficulty(song[i].id, "Normal") == recordData.records[j].songID)
                {
                    // i) 서버에 점수 기록이 있고, 로컬에도 점수 기록이 있음
                    if(PlayerPrefs.HasKey("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty))
                    {
                        if(recordData.records[j].score >= int.Parse(PlayerPrefs.GetString("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty)))
                        {
                            PlayerPrefs.SetString("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty, recordData.records[j].score.ToString("0000000"));
                        }
                    }

                    // ii) 서버에 점수 기록이 있고, 로컬에는 점수 기록이 없음
                    else
                    {
                        PlayerPrefs.SetString("SongScore" + song[i].songName + "Normal" + song[i].songNormalDifficulty, recordData.records[j].score.ToString("0000000"));
                    }

                    // I) 서버에 달성도 기록이 있고, 로컬에도 달성도 기록이 있음
                    if(PlayerPrefs.HasKey("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty))
                    {
                        if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty) == "SongProgressImageClear")
                        {
                            if(recordData.records[j].progress == "FullCombo")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageFullCombo");
                            }
                            else if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                        else if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty) == "SongProgressImageFullCombo")
                        {
                            if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                    }

                    // II) 서버에 달성도 기록이 있고, 로컬에는 달성도 기록이 없음
                    else
                    {
                        if(recordData.records[j].progress == "Clear")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageClear");
                        }
                        else if(recordData.records[j].progress == "FullCombo")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageFullCombo");
                        }
                        else if(recordData.records[j].progress == "AllAlive")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Normal" + song[i].songNormalDifficulty, "SongProgressImageAllAlive");
                        }
                    }
                }

                // 서버에 기록이 있음 (서버에 기록이 없다면 아무 일도 일어나지 않음)
                if(MakeIdWithDifficulty(song[i].id, "Hard") == recordData.records[j].songID)
                {
                    // i) 서버에 기록이 있고, 로컬에도 기록이 있음
                    if(PlayerPrefs.HasKey("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty))
                    {
                        if(recordData.records[j].score >= int.Parse(PlayerPrefs.GetString("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty)))
                        {
                            PlayerPrefs.SetString("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty, recordData.records[j].score.ToString("0000000"));
                        }
                    }

                    // ii) 서버에 기록이 있고, 로컬에는 기록이 없음
                    else
                    {
                        PlayerPrefs.SetString("SongScore" + song[i].songName + "Hard" + song[i].songHardDifficulty, recordData.records[j].score.ToString("0000000"));
                    }

                    // I) 서버에 달성도 기록이 있고, 로컬에도 달성도 기록이 있음
                    if(PlayerPrefs.HasKey("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty))
                    {
                        if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty) == "SongProgressImageClear")
                        {
                            if(recordData.records[j].progress == "FullCombo")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageFullCombo");
                            }
                            else if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                        else if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty) == "SongProgressImageFullCombo")
                        {
                            Debug.Log("good1");
                            if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                    }

                    // II) 서버에 달성도 기록이 있고, 로컬에는 달성도 기록이 없음
                    else
                    {
                        if(recordData.records[j].progress == "Clear")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageClear");
                        }
                        else if(recordData.records[j].progress == "FullCombo")
                        {
                            Debug.Log("good2");
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageFullCombo");
                        }
                        else if(recordData.records[j].progress == "AllAlive")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Hard" + song[i].songHardDifficulty, "SongProgressImageAllAlive");
                        }
                    }
                }

                // 서버에 기록이 있음 (서버에 기록이 없다면 아무 일도 일어나지 않음)
                if(MakeIdWithDifficulty(song[i].id, "Death") == recordData.records[j].songID)
                {
                    // i) 서버에 기록이 있고, 로컬에도 기록이 있음
                    if(PlayerPrefs.HasKey("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty))
                    {
                        if(recordData.records[j].score >= int.Parse(PlayerPrefs.GetString("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty)))
                        {
                            PlayerPrefs.SetString("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty, recordData.records[j].score.ToString("0000000"));
                        }
                    }

                    // ii) 서버에 기록이 있고, 로컬에는 기록이 없음
                    else
                    {
                        PlayerPrefs.SetString("SongScore" + song[i].songName + "Death" + song[i].songDeathDifficulty, recordData.records[j].score.ToString("0000000"));
                    }

                    // I) 서버에 달성도 기록이 있고, 로컬에도 달성도 기록이 있음
                    if(PlayerPrefs.HasKey("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty))
                    {
                        if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty) == "SongProgressImageClear")
                        {
                            if(recordData.records[j].progress == "FullCombo")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageFullCombo");
                            }
                            else if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                        else if(PlayerPrefs.GetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty) == "SongProgressImageFullCombo")
                        {
                            if(recordData.records[j].progress == "AllAlive")
                            {
                                PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageAllAlive");
                            }
                        }
                    }

                    // II) 서버에 달성도 기록이 있고, 로컬에는 달성도 기록이 없음
                    else
                    {
                        if(recordData.records[j].progress == "Clear")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageClear");
                        }
                        else if(recordData.records[j].progress == "FullCombo")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageFullCombo");
                        }
                        else if(recordData.records[j].progress == "AllAlive")
                        {
                            PlayerPrefs.SetString("SongProgress" + song[i].songName + "Death" + song[i].songDeathDifficulty, "SongProgressImageAllAlive");
                        }
                    }
                }
            }
        }

        
        
        
    }

    
}
