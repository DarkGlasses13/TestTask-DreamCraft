﻿namespace Assets._Project
{
    public class LevelMonoRunner : MonoRunner
    {
        private void Awake()
        {
            _runner = new LevelRunner(canEnableAllControllers: true);
        }

        private void Start()
        {
            _runner.RunAsync();
        }
    }
}