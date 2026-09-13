using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerator _generator;
        public GeneratorDirector(IBuilderGenerator generator)
        {
            SetBuilder(generator);
        }

        public void SetBuilder(IBuilderGenerator generator)
        {
            _generator = generator;
        }

        public void CreateSimpleJsonGenerator(List<string> content, string path)
        {
            _generator.Reset();
            _generator.SetContent(content);
            _generator.SetPath(path);
            _generator.SetFormat(TypeFormat.Json);
        }

        public void CreateSimplePipeGenerator(List<string> content, string path)
        {
            _generator.Reset();
            _generator.SetContent(content);
            _generator.SetPath(path);
            _generator.SetFormat(TypeFormat.Pipes);
            _generator.SetCharacter(TypeCharacter.Uppercase);
        }
    }
}
