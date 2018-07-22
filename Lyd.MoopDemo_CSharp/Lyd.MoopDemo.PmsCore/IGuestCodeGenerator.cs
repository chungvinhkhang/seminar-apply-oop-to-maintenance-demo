using System;
namespace Lyd.MoopDemo.PmsCore
{
    public interface IGuestCodeGenerator 
    {
        string Generate(Guest guest);
    }
}
