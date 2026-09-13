using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Generator
{
    public class GeneratorConcreteBuilder : IBuilderGenerator
    {
        private Generator _generator;
        public GeneratorConcreteBuilder()
        {
            _generator = new Generator();
        }
        public void Reset()
        {
            _generator = new Generator();
        }

        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal)
        {
            _generator.Character = character;
        }

        public void SetContent(List<string> content)
        {
            _generator.Content = content;
        }

        public void SetFormat(TypeFormat format)
        {
            _generator.Format = format;
        }

        public void SetPath(string path)
        {
            _generator.Path = path;
        }

        public Generator GetGenerator() => _generator;
    }
}
