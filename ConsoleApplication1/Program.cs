using System.Collections.Generic;
using System.IO;
using System.Threading;
using ConsoleApplication1.Actions;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllText(@"C:\Users\lucas.fernandes\Desktop\mapa1.txt")
                .Replace(@"\n", "")
                .Replace(@"\r", "");
            var mapGlobalSize = new CartesianSize(1024, 768);
            var mapLocalSize = new CartesianSize(108, 96);
            var pontoReferencia = new CartesianPointer(-100, -100);

            var b = new EnvironmentBuilder(mapGlobalSize)
                .PlotMap(file, mapLocalSize, pontoReferencia);
            
            var threadId = Thread.CurrentContext.ContextID.ToString();
            var h = new Helpers(new GetTaskStub(threadId, null), null, null, null, null, null );
        }

    }
    

    public class TemporalData
    {
        public string HelperName { get; set; }
        public int Date { get; set; }
        public int TaskCount { get; set; }
        public IList<int> TravelledDistance { get; set; }
        public int TotalTime { get; set; }
    }
    
    public interface IControllerEnviromentSimulator
    {
        IControllerEnviromentSimulator SetVirtualEnvioEnviroment(VirtualEnvironment env);
        IControllerEnviromentSimulator WithImpotedMaps(IList<object> maps);
        IList<TaskToExecute> TasksOfDay();
    }
}
