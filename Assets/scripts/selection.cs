
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selection : MonoBehaviour
{
    public Transform select;
    private RaycastHit raycastHit;

    public TextMeshProUGUI tmpro;
    public TextMeshProUGUI info;

    [SerializeField] Button visit;
    [SerializeField] GameObject panel;
    [SerializeField] Button pausebtn;
    [SerializeField] Slider speed;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {

                if (select != null && !ClickedOnUi())
                {
                    select.GetChild(0).gameObject.SetActive(false);

                    panel.SetActive(false);
                    visit.gameObject.SetActive(false);
                    speed.gameObject.SetActive(true);

                select = null;
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit) && raycastHit.transform.CompareTag("Celestial"))
                {
                    select = raycastHit.transform;

                    select.GetChild(0).gameObject.SetActive(true);

                    panel.SetActive(true);
                    visit.gameObject.SetActive(true);
                    speed.gameObject.SetActive(false);

                    tmpro.text = planetname(select);
                    info.text = planetinfo(select);
                }
                else
                {
                    
                }
        }
        
    }
    
    string planetname(Transform select)
    {
        switch(select.name)
        {
            case "sunsphere": return "Sun";
            case "mercury": return "Mercury";
            case "venus": return "Venus";
            case "earth": return "Earth";
            case "mars": return "Mars";
            case "jupiter": return "Jupiter";
            case "saturn": return "Saturn";
            case "uranus": return "Uranus";
            case "neptune": return "Neptune";
            case "pluto": return "Pluto";
            case "moon": return "Moon";

            default: return "";
        }
    }

    string planetinfo(Transform select)
    {
        switch (select.name)
        {
            case "sunsphere": 
                return "MASS\t\t\t    1.99 X 10^30 KG\r\nDIAMETER\t\t    1.39 M KM \r\nROTATION PERIOD\t    25 DAYS\r\nORBIT PERIOD\t \t    225 M YEARS\r\nSURFACE GRAVITY\t    274 M/S²\r\nSURFACE TEMP.\t    5505°C\r\n\r\nThe Sun, also referred to as Sol, is the star at the center of the Solar System. Sun's mass accounts for some 99.86% of the total mass of the Solar System";


            case "mercury":
                return "MASS\t\t\t    3.3 X 10^23 KG\r\nDIAMETER\t\t    4879 KM \r\nDIST. FROM SUN\t    58.2 M KM\r\nROTATION PERIOD\t    59 DAYS\r\nORBIT PERIOD\t \t    88 DAYS\r\nSURFACE GRAVITY\t    3.7 M/S²\r\nSURFACE TEMP.\t    167°C\r\n\r\nMercury is the innermost and smallest planet of the Solar System. Because it has almost no atmosphere to retain heat, Mercury's surface experiences greatest temperature variation of all the planet";


            case "venus": 
                return "MASS\t\t\t    4.9 X 10^24 KG\r\nDIAMETER\t\t    12104 KM \r\nDIST. FROM SUN\t    108 M KM\r\nROTATION PERIOD\t    243 DAYS\r\nORBIT PERIOD\t \t    225 DAYS\r\nSURFACE GRAVITY\t    8.9 M/S²\r\nSURFACE TEMP.\t    462°C\r\n\r\nAlthough Venus has very similar size and interior structure as Earth, its vulcanic surface and extremely hot and dense atmosphere makes it one of the most inhabitable places in the Solar System";


            case "earth": 
                return "MASS\t\t\t    6 X 10^24 KG\r\nDIAMETER\t\t    12756 KM \r\nDIST. FROM SUN\t    150 M KM\r\nROTATION PERIOD\t    24 HOURS\r\nORBIT PERIOD\t \t    1 YEAR\r\nSURFACE GRAVITY\t    9.8 M/S²\r\nSURFACE TEMP.\t    15°C\r\n\r\nOur homeworld is the densest of the eight planets in the Solar System. It is also the largest of the four terrestrial planets";

            case "mars":
                return "MASS\t\t\t    6.4 X 10^23 KG\r\nDIAMETER\t\t    6792 KM \r\nDIST. FROM SUN\t    228 M KM\r\nROTATION PERIOD\t    1.03 DAYS\r\nORBIT PERIOD\t \t    1.88 YEAR\r\nSURFACE GRAVITY\t    3.7 M/S²\r\nSURFACE TEMP.\t    -63°C\r\n\r\nMars is the fourth planet from the Sun and the second smallest planet in the Solar System. The reddish appearance of Mars' surface is caused by iron oxide(rust)";


            case "jupiter": 
                return "MASS\t\t\t    1.9 X 10^27 KG\r\nDIAMETER\t\t    142984 KM \r\nDIST. FROM SUN\t    778 M KM\r\nROTATION PERIOD\t    9H 55M\r\nORBIT PERIOD\t \t    11.9 YEARS\r\nSURFACE GRAVITY\t    25 M/S²\r\nSURFACE TEMP.\t    -120°C\r\n\r\nJupiter is the largest planet of the Solar System, with a mass 2.5 greater than all of the rest of the planets combined - but still is only one-thousandth that of the Sun";


            case "saturn": 
                return "MASS\t\t\t    5.7 X 10^26 KG\r\nDIAMETER\t\t    120536 KM \r\nDIST. FROM SUN\t    9.58 AU\r\nROTATION PERIOD\t    10H 39M\r\nORBIT PERIOD\t \t    29 YEARS\r\nSURFACE GRAVITY\t    10.4 M/S²\r\nSURFACE TEMP.\t    -139°C\r\n\r\nSaturn is the sixth planet from the Sun and the second largest planet in the Solar System. Until the invention of modern telescope, Saturn was regarded as the outermost of the known planets";


            case "uranus":
                return "MASS\t\t\t    8.7 X 10^25 KG\r\nDIAMETER\t\t    51118 KM \r\nDIST. FROM SUN\t    19.2 AU\r\nROTATION PERIOD\t    17H 14M\r\nORBIT PERIOD\t \t    84 YEARS\r\nSURFACE GRAVITY\t    8.7 M/S²\r\nSURFACE TEMP.\t    -210°C\r\n\r\nUranus is the third largest of the Solar System's gas giants. It is the coldest planet in the Solar system"; 


            case "neptune":
                return "MASS\t\t\t    1.02 X 10^26 KG\r\nDIAMETER\t\t    49528 KM \r\nDIST. FROM SUN\t    30.1 AU\r\nROTATION PERIOD\t    16H 06M\r\nORBIT PERIOD\t \t    165 YEARS\r\nSURFACE GRAVITY\t    11.2 M/S²\r\nSURFACE TEMP.\t    -200°C\r\n\r\nNeptune is the eight and officially farthest planet from the Sun. It is the smallest but also the most dense of gas giants. Neptune has a surface gravity that is only surpassed by Jupiter";


            case "pluto":
                return "MASS\t\t\t    1.31 X 10^22 KG\r\nDIAMETER\t\t    2374 KM \r\nDIST. FROM SUN\t    40.9 AU\r\nROTATION PERIOD\t    6.4 DAYS\r\nORBIT PERIOD\t \t    248 YEARS\r\nSURFACE GRAVITY\t    0.66 M/S²\r\nSURFACE TEMP.\t    -228°C\r\n\r\nPluto is the largest object in the kuiper belt. It is also the largest and the second most massive known dwarf planet in the Solar System";

            case "moon":
                return "MASS\t\t\t    7.3 X 10^22 KG\r\nDIAMETER\t\t    3476 KM \r\nDIST. FROM EARTH\t    384033 KM\r\nROTATION PERIOD\t    27 DAYS\r\nORBIT PERIOD\t \t    27 DAYS\r\nSURFACE GRAVITY\t    1.62 M/S²\r\nSURFACE TEMP.\t    -23°C\r\n\r\nThe Moon is Earth's only natural satellite. Next to the Sun, the Moon exerts the greatest influence on the Earth itself, most notably through its affect on Earth's tides";


            default: return "";
        }
    }

    bool ClickedOnUi()
    {

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.GetTouch(0).position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        // return results.Count > 0;
        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("UI"))
            {
                return true;
            }
        }
        return false;
    }

}
