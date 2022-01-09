using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer soundsAudioMixer;

    Resolution[] resolutions;
    public Dropdown resolutionsDropdown;

    //G�re le volume de la musique du jeu
    public void SetVolumeMusic(float musicVolume)
    {
        musicAudioMixer.SetFloat("MusicVolume", musicVolume);
    }

    //g�re le volume des bruitages
    public void SetVolumeSounds(float soundsVolume)
    {
        soundsAudioMixer.SetFloat("SoundsVolume", soundsVolume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }





    public void Start()
    {
        //Param�tre de r�solution de l'�cran du joueur
            resolutions = Screen.resolutions;
            resolutionsDropdown.ClearOptions();

            List<string> options = new List<string>();

            for (int i = 0; i < resolutions.Length; i++)
            {
                //on cr�er une string contenant la r�solution de l'�cran du joueur car le Dropdown ne peut contenir que des strings
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);
            }

            resolutionsDropdown.AddOptions(options); //on envoie la liste de toutes les options de r�solution � la liste d�roulante du menu des Settings
        //----------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
