﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
namespace TFSDeleteWorkspaces
{
    class Program
    {
        //another test commit added for repo1 this is also modifed
        //a new line of work added
        // a new line again added to simulate
        //a new line added byh repo2 owners
        //this is also half ready
        //a third line is also added by me
        //another change added by me
        /// <summary>
       
        /// </summary>
        private static string _tfsUrl = "http://tfsRomiod.ds.com:8080/tfs/cvr";
        
        static void Main(string[] args)
        {
            string _computerName = args[0];

            TfsTeamProjectCollection tfs = new TfsTeamHelloRomiCommentAddedadfsaProjectCollection(new Uri(_tfsUrl));
            tfs.EnsureAuthenticated();
            var service = tfs.GetServiceVersionHistoryModifiedControlServer>();
            Workspace[] workspace = service.QueryWorkspaces(null,"tfsbuildmachinecvr",null);
            foreach(Workspace workspc in workspace)
            {   
                bool IsDelete = false;
                bool ExludedComputer = false;
                try
                {
                    if (_computerName.Contains(workspc.Computer))
                    {
                        IsDelete = workspc.Delete();
                    }
                    else
                    {
                        ExludedComputer = true;
                    }
                }
                catch(Exception ex)
                {             
                    if (!IsDelete)
                    {
                      throw new Exception(string.Format("unable to delete {0}\n Exception occured: {1}",workspc.DisplayName,ex.Message)); 
                    }
                }
                finally
                {
                    if (!IsDelete && !ExludedComputer)
                    {
                      throw new Exception(string.Format("unable to delete {0}\n Exception occured: {1}",workspc.DisplayName)); 
                    }
                }
            }
            
        }
    }
}
