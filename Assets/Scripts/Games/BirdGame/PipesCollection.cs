using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.BirdGame
{
    [ExecuteAlways]
    public class PipesCollection : MonoBehaviour
    {
        private readonly List<Pipe> _pipes = new List<Pipe>();
        public IReadOnlyList<Pipe> Pipes => _pipes;

        private void OnEnable()
        {
            Pipe.PipeCreated += Pipe_PipeCreated;
            Pipe.PipeDestroyed += Pipe_PipeDestroyed;
        }

        private void Pipe_PipeCreated(Pipe arg0)
        {
            TryAddToCollection(arg0);
        }

        private void Pipe_PipeDestroyed(Pipe arg0)
        {
            TryRemoveFromCollection(arg0);
        }

        private void OnDisable()
        {
            Pipe.PipeCreated -= Pipe_PipeCreated;
            Pipe.PipeDestroyed -= Pipe_PipeDestroyed;
        }

        private void Update()
        {

        }

        private void TryAddToCollection(Pipe pipe)
        {
            if (_pipes.Contains(pipe) == false)
            {
                _pipes.Add(pipe);
                Debug.Log("pipe added");
            }
        }

        private void TryRemoveFromCollection(Pipe pipe)
        {
            if (_pipes.Contains(pipe) == false)
            {
                _pipes.Add(pipe);
                Debug.Log("pipe removed");
            }
        }
    }
}
