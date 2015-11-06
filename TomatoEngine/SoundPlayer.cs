﻿using System.Collections.Generic;
using System.Media;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;

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
        private static MediaLibrary _playlist = new MediaLibrary();
        static SoundPool()
        {
            FrameworkDispatcher.Update();
        }

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

        public static void PlayBackgroundMusic()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(_playlist.Songs[0]);
            
        }
        public static void PlayBackgroundMusic(string name)
        {
            string locationString = ResourceManager.GetSoundLocationByName(name);
            Uri location = new Uri(locationString);
            MediaPlayer.Stop();
            MediaPlayer.Play(Song.FromUri(name, location));

        }

    }
}
