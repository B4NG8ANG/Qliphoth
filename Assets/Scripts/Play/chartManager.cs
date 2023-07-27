using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chartManager : MonoBehaviour
{
    public Dictionary<string, Dictionary<int, string[]>> chartContainer = new Dictionary<string, Dictionary<int, string[]>>();

    // Fracture Ray Normal
    Dictionary<int, string[]> Fracture_Ray_Normal4 = new Dictionary<int, string[]>()
    {
        // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}

        // {0, new string[]{"normalNote", "1.0", "(100,300,0)", "0", "false", ""}},
        // {1, new string[]{"smallNormalNote", "2.0", "(300,300,0)", "1", "false", ""}},
        // {2, new string[]{"slideNote", "3.0", "(100,500,0)", "2", "false", ""}},
        // {3, new string[]{"slideNote", "4.0", "(500,500,0)", "3", "false", ""}},
        // {4, new string[]{"longNote", "5.0", "(600,500,0)", "4", "false", "1.0"}},
        // {5, new string[]{"bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""}},
        // {6, new string[]{"normalNote", "7.0", "(800,200,0)", "6", "false", ""}},
        // {7, new string[]{"normalNote", "8.0", "(900,200,0)", "7", "false", ""}},
        // {8, new string[]{"normalNote", "9.0", "(900,300,0)", "8", "false", ""}},
        // {9, new string[]{"normalNote", "10.0", "(700,400,0)", "9", "false", ""}},
        // {10, new string[]{"slideNote", "11.0", "(800,500,0)", "10", "false", ""}},
        // {11, new string[]{"slideNote", "11.1", "(900,600,0)", "11", "false", ""}},
        // {12, new string[]{"slideNote", "11.2", "(1000,700,0)", "12", "false", ""}},
        // {13, null}

        // {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        // {1, new string[]{"longNote", "2.0", "(700,700,0)", "1", "false", "2.0"}},
        // {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        // {3, null}

        {0, new string[]{"longNote", "1.0", "(300,300,0)", "0", "false", "1.0"}},
        {1, new string[]{"longNote", "2.0", "(700,700,0)", "1", "false", "2.0"}},
        {2, new string[]{"longNote", "5.0", "(600,600,0)", "2", "false", "5.0"}},
        {3, null}
        
    };

    // Fracture Ray Hard
    Dictionary<int, string[]> Fracture_Ray_Hard6 = new Dictionary<int, string[]>()
    {
        // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}

        // {0, new string[]{"normalNote", "1.0", "(100,300,0)", "0", "false", ""}},
        // {1, new string[]{"smallNormalNote", "2.0", "(300,300,0)", "1", "false", ""}},
        // {2, new string[]{"slideNote", "3.0", "(100,500,0)", "2", "false", ""}},
        // {3, new string[]{"slideNote", "4.0", "(500,500,0)", "3", "false", ""}},
        // {4, new string[]{"longNote", "5.0", "(600,500,0)", "4", "false", "1.0"}},
        // {5, new string[]{"bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""}},
        // {6, new string[]{"normalNote", "7.0", "(800,200,0)", "6", "false", ""}},
        // {7, new string[]{"normalNote", "8.0", "(900,200,0)", "7", "false", ""}},
        // {8, new string[]{"normalNote", "9.0", "(900,300,0)", "8", "false", ""}},
        // {9, new string[]{"normalNote", "10.0", "(700,400,0)", "9", "false", ""}},
        // {10, new string[]{"slideNote", "11.0", "(800,500,0)", "10", "false", ""}},
        // {11, new string[]{"slideNote", "11.1", "(900,600,0)", "11", "false", ""}},
        // {12, new string[]{"slideNote", "11.2", "(1000,700,0)", "12", "false", ""}},
        // {13, null}

        {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        {1, new string[]{"longNote", "2.0", "(700,700,0)", "1", "false", "2.0"}},
        {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        {3, null}

        // {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        // {1, new string[]{"normalNote", "2.0", "(700,700,0)", "1", "false", ""}},
        // {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        // {3, null}
        
    };

    // Fracture Ray Death
    Dictionary<int, string[]> Fracture_Ray_Death9 = new Dictionary<int, string[]>()
    {
        // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}

        {0, new string[]{"normalNote", "1.0", "(100,300,0)", "0", "false", ""}},
        {1, new string[]{"smallNormalNote", "2.0", "(300,300,0)", "1", "false", ""}},
        {2, new string[]{"slideNote", "3.0", "(100,500,0)", "2", "false", ""}},
        {3, new string[]{"slideNote", "4.0", "(500,500,0)", "3", "false", ""}},
        {4, new string[]{"longNote", "5.0", "(600,500,0)", "4", "false", "1.0"}},
        {5, new string[]{"bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""}},
        {6, new string[]{"normalNote", "7.0", "(800,200,0)", "6", "false", ""}},
        {7, new string[]{"normalNote", "9.0", "(900,200,0)", "7", "true", ""}},
        {8, new string[]{"normalNote", "9.0", "(900,600,0)", "8", "true", ""}},
        {9, new string[]{"normalNote", "10.0", "(700,400,0)", "9", "false", ""}},
        {10, new string[]{"slideNote", "11.0", "(800,500,0)", "10", "false", ""}},
        {11, new string[]{"slideNote", "11.1", "(900,600,0)", "11", "false", ""}},
        {12, new string[]{"slideNote", "11.2", "(1000,700,0)", "12", "false", ""}},
        {13, null}

        // {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        // {1, new string[]{"longNote", "2.0", "(700,700,0)", "1", "false", "2.0"}},
        // {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        // {3, null}

        // {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        // {1, new string[]{"normalNote", "2.0", "(700,700,0)", "1", "false", ""}},
        // {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        // {3, null}
        
    };

    // Cytus II Death
    Dictionary<int, string[]> Cytus_II_Death5 = new Dictionary<int, string[]>()
    {
        // {노트 순서(key값) , new string[]{노트 종류, 노트가 생성될 시각, 노트가 생성될 vector3 좌표, 노트 번호, 동타 여부, 롱 노트인 경우 지속시간}}

        // {0, new string[]{"normalNote", "1.0", "(100,300,0)", "0", "false", ""}},
        // {1, new string[]{"smallNormalNote", "2.0", "(300,300,0)", "1", "false", ""}},
        // {2, new string[]{"slideNote", "3.0", "(100,500,0)", "2", "false", ""}},
        // {3, new string[]{"slideNote", "4.0", "(500,500,0)", "3", "false", ""}},
        // {4, new string[]{"longNote", "5.0", "(600,500,0)", "4", "false", "1.0"}},
        // {5, new string[]{"bigNormalNote", "6.0", "(900,200,0)", "5", "false", ""}},
        // {6, new string[]{"normalNote", "7.0", "(800,200,0)", "6", "false", ""}},
        // {7, new string[]{"normalNote", "8.0", "(900,200,0)", "7", "false", ""}},
        // {8, new string[]{"normalNote", "9.0", "(900,300,0)", "8", "false", ""}},
        // {9, new string[]{"normalNote", "10.0", "(700,400,0)", "9", "false", ""}},
        // {10, new string[]{"slideNote", "11.0", "(800,500,0)", "10", "false", ""}},
        // {11, new string[]{"slideNote", "11.1", "(900,600,0)", "11", "false", ""}},
        // {12, new string[]{"slideNote", "11.2", "(1000,700,0)", "12", "false", ""}},
        // {13, null}

        // {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        // {1, new string[]{"longNote", "2.0", "(700,700,0)", "1", "false", "2.0"}},
        // {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        // {3, null}

        // {0, new string[]{"normalNote", "1.0", "(300,300,0)", "0", "false", ""}},
        // {1, new string[]{"normalNote", "2.0", "(700,700,0)", "1", "false", ""}},
        // {2, new string[]{"normalNote", "5.0", "(600,600,0)", "2", "false", ""}},
        // {3, null}

        {0, new string[]{"slideNote", "1.0", "(300,300,0)", "0", "false", ""}},
        {1, new string[]{"slideNote", "2.0", "(700,700,0)", "1", "false", ""}},
        {2, new string[]{"slideNote", "5.0", "(600,600,0)", "2", "false", ""}},
        {3, new string[]{"slideNote", "7.0", "(600,600,0)", "3", "false", ""}},
        {4, null}
        
    };


    void Start()
    {
        chartContainer["Fracture_Ray_Normal4"] = Fracture_Ray_Normal4;
        chartContainer["Fracture_Ray_Hard6"] = Fracture_Ray_Hard6;
        chartContainer["Fracture_Ray_Death9"] = Fracture_Ray_Death9;
        chartContainer["Cytus_II_Death5"] = Cytus_II_Death5;
    }

}
