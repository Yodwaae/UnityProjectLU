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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }



    public void Start()
    {
        //Param�tre de r�solution de l'�cran du joueur
            resolutions = Screen.resolutions;
            resolutionsDropdown.ClearOptions();

            int currentResolutionIndex = 0;

            List<string> options = new List<string>();

            for (int i = 0; i < resolutions.Length; i++)
            {
                //on cr�er une string contenant la r�solution de l'�cran du joueur car le Dropdown ne peut contenir que des strings
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                //v�rification : est ce que la r�solution actuelle correspond � la taille de l'�cran du joueur
                if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionsDropdown.AddOptions(options); //on envoie la liste de toutes les options de r�solution � la liste d�roulante du menu des Settings

            //on lance la meilleure r�solution possible
            resolutionsDropdown.value = currentResolutionIndex;
            resolutionsDropdown.RefreshShownValue(); //raffraichit l'�l�ment s�lectionner dans la liste d�roulante du menu des options
        //----------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
