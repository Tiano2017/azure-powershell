﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmRouteTable"), OutputType(typeof(PSRouteTable))]
    public class GetAzureRouteTableCommand : RouteTableBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var routeTable = this.GetRouteTable(this.ResourceGroupName, this.Name, this.ExpandResource);

                WriteObject(routeTable);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var routeTableList = this.RouteTableClient.List(this.ResourceGroupName);

                var psRouteTables = new List<PSRouteTable>();

                foreach (var routeTable in routeTableList)
                {
                    var psRouteTable = this.ToPsRouteTable(routeTable);
                    psRouteTable.ResourceGroupName = this.ResourceGroupName;
                    psRouteTables.Add(psRouteTable);
                }

                WriteObject(psRouteTables, true);
            }
            else
            {
                var routeTableList = this.RouteTableClient.ListAll();

                var psRouteTables = new List<PSRouteTable>();

                foreach (var routeTable in routeTableList)
                {
                    var psRouteTable = this.ToPsRouteTable(routeTable);
                    psRouteTable.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(routeTable.Id);
                    psRouteTables.Add(psRouteTable);
                }

                WriteObject(psRouteTables, true);
            }
        }
    }
}
