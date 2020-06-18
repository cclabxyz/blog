
using System;
using Microsoft.MetadirectoryServices;

namespace Mms_Metaverse
{
	/// <summary>
	/// Summary description for MVExtensionObject.
	/// </summary>
    public class MVExtensionObject : IMVSynchronization
    {
        public MVExtensionObject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        void IMVSynchronization.Initialize ()
        {
            //
            // TODO: Add initialization logic here
            //
        }

        void IMVSynchronization.Terminate ()
        {
            //
            // TODO: Add termination logic here
            //
        }

        void IMVSynchronization.Provision (MVEntry mventry)
        {
            ConnectedMA ManagementAgent;
            int Connectors;

            if (mventry.ObjectType == "person") {
                ManagementAgent = mventry.ConnectedMAs["AD-CCLAB"];
                Connectors = ManagementAgent.Connectors.Count;

                if(Connectors == 0) {
                    CreateADAccount(mventry);
                }
            }
            
        }	

        private bool CreateADAccount (MVEntry mventry) {
            ConnectedMA ManagementAgent;
            ReferenceValue dn;
            CSEntry csentry;
            string OU = "OU=Users,OU=CCLAB,DC=cclab,DC=xyz";
            string accountName;
            string relativeDN;
            string pass;

            ManagementAgent = mventry.ConnectedMAs["AD-CCLAB"];
            if (mventry["accountName"].IsPresent) {
                accountName = mventry["accountName"].Value;
                relativeDN = "CN=" + accountName;
                dn = ManagementAgent.EscapeDNComponent(relativeDN).Concat(OU);
                pass = "MyPass" + mventry["Pesel"].Value;

                csentry = ManagementAgent.Connectors.StartNewConnector("user");
                csentry.DN = dn;
                csentry["sAMAccountName"].Value = accountName;
                csentry["unicodePWD"].Value = pass;
                csentry["pwdLastSet"].IntegerValue = 0;
                csentry["userAccountControl"].IntegerValue = 0x0200;
                csentry["userPrincipalName"].Value = accountName + "@cclab.xyz";
                csentry.CommitNewConnector();

                return true;
            } else {
                return false;
            }    
        }

        bool IMVSynchronization.ShouldDeleteFromMV (CSEntry csentry, MVEntry mventry)
        {
            //
            // TODO: Add MV deletion logic here
            //
            throw new EntryPointNotImplementedException();
        }
    }
}
