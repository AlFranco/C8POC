﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="C8WindowsContainer.cs" company="AlFranco">
//   Albert Rodriguez Franco 2013
// </copyright>
// <summary>
//   Defines the C8WindowsContainer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace C8POC.WinFormsUI.Container
{
    using Autofac;
    using Autofac.Extras.DynamicProxy2;

    using C8POC.Core.Domain.Engines;
    using C8POC.Core.Domain.Entities;
    using C8POC.Core.Domain.Services;
    using C8POC.Interfaces.Domain.Engines;
    using C8POC.Interfaces.Domain.Entities;
    using C8POC.Interfaces.Domain.Services;
    using C8POC.Interfaces.Infrastructure.Services;
    using C8POC.WinFormsUI.Disassembly;
    using C8POC.WinFormsUI.Forms;
    using C8POC.WinFormsUI.Services;

    /// <summary>
    /// Container to resolve instances from the Windows Version of C8POC
    /// </summary>
    public class C8WindowsContainer : ContainerBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="C8WindowsContainer"/> class.
        /// </summary>
        public C8WindowsContainer()
        {
            this.RegisterType<C8Engine>().As<C8Engine>();
            this.RegisterType<C8MachineState>().As<IMachineState>();
            this.RegisterType<WindowsConfigurationService>().As<IConfigurationService>();
            this.RegisterType<WindowsPluginService>().As<IPluginService>();
            this.RegisterType<OpcodeProcessor>().As<IOpcodeProcessor>();
            this.RegisterType<WindowsRomService>().As<IRomService>();
            this.RegisterType<WindowsOpcodeMapService>().As<IOpcodeMapService>();

            // Mediator
            this.RegisterType<EngineMediator>().As<IEngineMediator>();
            this.RegisterType<InputOutputEngine>().As<IInputOutputEngine>();
            this.RegisterType<ExecutionEngine>().As<IExecutionEngine>();
            this.RegisterType<ConfigurationEngine>().As<IConfigurationEngine>();
        }

        /// <summary>
        /// Enables the disassembler with the given container
        /// </summary>
        /// <param name="disassemblerForm">
        /// The disassembler form.
        /// </param>
        public void EnableDisassembler(DisassemblerForm disassemblerForm)
        {
            this.Register(x => new MachineDisassemblerInterceptor(disassemblerForm));

            this.RegisterType<OpcodeProcessor>()
                .As<IOpcodeProcessor>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MachineDisassemblerInterceptor));
        }
    }
}
