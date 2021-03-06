//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateVirtualMachineExtensionCreateOrUpdateDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pVMName = new RuntimeDefinedParameter();
            pVMName.Name = "VMName";
            pVMName.ParameterType = typeof(string);
            pVMName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pVMName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VMName", pVMName);

            var pVMExtensionName = new RuntimeDefinedParameter();
            pVMExtensionName.Name = "VMExtensionName";
            pVMExtensionName.ParameterType = typeof(string);
            pVMExtensionName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = true
            });
            pVMExtensionName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VMExtensionName", pVMExtensionName);

            var pExtensionParameters = new RuntimeDefinedParameter();
            pExtensionParameters.Name = "VirtualMachineExtensionCreateOrUpdateExtensionParameter";
            pExtensionParameters.ParameterType = typeof(VirtualMachineExtension);
            pExtensionParameters.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 4,
                Mandatory = true
            });
            pExtensionParameters.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VirtualMachineExtensionCreateOrUpdateExtensionParameter", pExtensionParameters);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 5,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteVirtualMachineExtensionCreateOrUpdateMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string vmName = (string)ParseParameter(invokeMethodInputParameters[1]);
            string vmExtensionName = (string)ParseParameter(invokeMethodInputParameters[2]);
            VirtualMachineExtension extensionParameters = (VirtualMachineExtension)ParseParameter(invokeMethodInputParameters[3]);

            var result = VirtualMachineExtensionsClient.CreateOrUpdate(resourceGroupName, vmName, vmExtensionName, extensionParameters);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateVirtualMachineExtensionCreateOrUpdateParameters()
        {
            string resourceGroupName = string.Empty;
            string vmName = string.Empty;
            string vmExtensionName = string.Empty;
            VirtualMachineExtension extensionParameters = new VirtualMachineExtension();

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "VMName", "VMExtensionName", "ExtensionParameters" },
                 new object[] { resourceGroupName, vmName, vmExtensionName, extensionParameters });
        }
    }
}
