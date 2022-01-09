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

    //Gère le volume de la musique du jeu
    public void SetVolumeMusic(float musicVolume)
    {
        musicAudioMixer.SetFloat("MusicVolume", musicVolume);
    }

    //gère le volume des bruitages
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
        //Paramètre de résolution de l'écran du joueur
            resolutions = Screen.resolutions;
            resolutionsDropdown.ClearOptions();

            int currentResolutionIndex = 0;

            List<string> options = new List<string>();

            for (int i = 0; i < resolutions.Length; i++)
            {
                //on créer une string contenant la résolution de l'écran du joueur car le Dropdown ne peut contenir que des strings
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                //vérification : est ce que la résolution actuelle correspond à la taille de l'écran du joueur
                if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionsDropdown.AddOptions(options); //on envoie la liste de toutes les options de résolution à la liste déroulante du menu des Settings

            //on lance la meilleure résolution possible
            resolutionsDropdown.value = currentResolutionIndex;
            resolutionsDropdown.RefreshShownValue(); //raffraichit l'élément sélectionner dans la liste déroulante du menu des options
        //----------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
