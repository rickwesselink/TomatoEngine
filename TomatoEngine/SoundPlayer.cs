﻿using System.Collections.Generic;
using System.Media;

namespace TomatoEngine
{
    class AudioObject
    {
        public string sLocation = "";
        private SoundPlayer _tomatoPlayer;
        public AudioObject(string location, bool playAudio)
        {
            if(location != ""){
                sLocation = location;
                _tomatoPlayer = new SoundPlayer(location);
                if (playAudio)
                {
                    _tomatoPlayer.Play();
                }
                else
                {
                    _tomatoPlayer.Stop();
                }
            }
        }
        public void Play()
        {
            _tomatoPlayer.Play();
        }
    }



    public static class SoundPool
    {
        private static List<AudioObject> _AudioObjectList = new List<AudioObject>();
        public static void PlaySound(string name)
        {
            string location = ResourceManager.GetSoundLocationByName(name);
            AudioObject ex = null;
            foreach(AudioObject x in _AudioObjectList)
            {
                if (x.sLocation.Equals(location))
                {
                    ex = x;
                }
            }
            if (ex == null)
            {
                _AudioObjectList.Add(new AudioObject(location, true));
            }
            else
            {
                ex.Play();
            }
        }
    }
}
