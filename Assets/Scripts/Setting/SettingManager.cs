using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;
    public Slider brightSlider;
    public GameObject volumeText;
    public GameObject brightText;
    public float volumeInitialValue;
    public float brightInitialValue;
    public float volumeAmount;
    public float brightAmount;
    public GameObject brightSettingImage;
    public Color brightSettingImageAlpha;
    public GameObject userName;
    
    void Start()
    {   
        // 상단 메뉴바에 닉네임 표시
        if(AuthManager.Instance.isLogIn)
        {
            userName.GetComponent<Text>().text = AuthManager.Instance.UserName;
        }
        else
        {
            userName.GetComponent<Text>().text = "Guest";
        }
        
        // 볼륨 초기 값 설정
        if (!(PlayerPrefs.HasKey("VolumeAmount")))
        {
            Debug.Log("볼륨 초기 값으로 세팅");
            volumeSlider.value = volumeInitialValue;
            PlayerPrefs.SetString("VolumeAmount", volumeSlider.value.ToString());
        }
        else
        {
            Debug.Log("볼륨 이미 저장된 값으로 세팅");
            volumeSlider.value = float.Parse(PlayerPrefs.GetString("VolumeAmount"));
        }

        // 밝기 초기 값 설정
        if (!(PlayerPrefs.HasKey("BrightAmount")))
        {
            Debug.Log("밝기 초기 값으로 세팅");
            brightSlider.value = brightInitialValue;
            PlayerPrefs.SetString("BrightAmount", brightSlider.value.ToString());
        }
        else
        {
            Debug.Log("밝기 이미 저장된 값으로 세팅");
            brightSlider.value = float.Parse(PlayerPrefs.GetString("BrightAmount"));
        }

        // 키 값이 있는지 검사하기 전 슬라이더 값이 변경되지 않도록 리스너를 나중에 등록
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        brightSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // 오디오 믹서에 설정한 파라미터 값을 이용하여 설정된 볼륨 값으로 믹서의 볼륨 조절
        mixer.SetFloat("BackGroundMusicVolume",Mathf.Log10(volumeSlider.value) * 20);

        // 밝기 설정 이미지의 투명도를 조절하여 화면 밝기 조절
        brightSettingImageAlpha = brightSettingImage.GetComponent<Image>().color;
        brightSettingImageAlpha.a = brightSlider.value;
        brightSettingImage.GetComponent<Image>().color = brightSettingImageAlpha;
    }

    void Update()
    {
        // 슬라이더의 value값은 0과 1사이의 값이므로 100을 곱한 후 반올림해서 보여주어야 함
        volumeAmount = volumeSlider.value * 100f;
        brightAmount = 100 - (brightSlider.value * 100f);

        volumeText.GetComponent<Text>().text = Mathf.Round(volumeAmount).ToString();
        brightText.GetComponent<Text>().text = Mathf.Round(brightAmount).ToString();
    }

    // 슬라이더 값이 변경될 때 호출될 함수
    private void OnSliderValueChanged(float newValue)
    {
        PlayerPrefs.SetString("VolumeAmount", volumeSlider.value.ToString());
        PlayerPrefs.SetString("BrightAmount", brightSlider.value.ToString());

        // 오디오 믹서에 설정한 파라미터 값을 이용하여 설정된 볼륨 값으로 믹서의 볼륨 조절
        mixer.SetFloat("BackGroundMusicVolume",Mathf.Log10(volumeSlider.value) * 20);

        // 밝기 설정 이미지의 투명도를 조절하여 화면 밝기 조절
        brightSettingImageAlpha = brightSettingImage.GetComponent<Image>().color;
        brightSettingImageAlpha.a = brightSlider.value;
        brightSettingImage.GetComponent<Image>().color = brightSettingImageAlpha;

    }
}
