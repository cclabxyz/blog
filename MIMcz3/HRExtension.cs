
using System;
using Microsoft.MetadirectoryServices;

namespace Mms_ManagementAgent_HRExtension
{
    /// <summary>
    /// Summary description for MAExtensionObject.
	/// </summary>
	public class MAExtensionObject : IMASynchronization
	{
		public MAExtensionObject()
		{
            //
            // TODO: Add constructor logic here
            //
        }
		void IMASynchronization.Initialize ()
		{
            //
            // TODO: write initialization code
            //
        }

        void IMASynchronization.Terminate ()
        {
            //
            // TODO: write termination code
            //
        }

        bool IMASynchronization.ShouldProjectToMV (CSEntry csentry, out string MVObjectType)
        {
			//
			// TODO: Remove this throw statement if you implement this method
			//
			throw new EntryPointNotImplementedException();
		}

        DeprovisionAction IMASynchronization.Deprovision (CSEntry csentry)
        {
			//
			// TODO: Remove this throw statement if you implement this method
			//
			throw new EntryPointNotImplementedException();
        }	

        bool IMASynchronization.FilterForDisconnection (CSEntry csentry)
        {
            //
            // TODO: write connector filter code
            //
            throw new EntryPointNotImplementedException();
		}

		void IMASynchronization.MapAttributesForJoin (string FlowRuleName, CSEntry csentry, ref ValueCollection values)
        {
            //
            // TODO: write join mapping code
            //
            throw new EntryPointNotImplementedException();
        }

        bool IMASynchronization.ResolveJoinSearch (string joinCriteriaName, CSEntry csentry, MVEntry[] rgmventry, out int imventry, ref string MVObjectType)
        {
            //
            // TODO: write join resolution code
            //
            throw new EntryPointNotImplementedException();
		}

        void IMASynchronization.MapAttributesForImport( string FlowRuleName, CSEntry csentry, MVEntry mventry)
        {
            //
            // TODO: write your import attribute flow code
            //
            switch (FlowRuleName)
			{
				case "accountName":
					
                    // Declare needed vars
                    string finalaccountname = string.Empty;
                    string IDprefix = "ID";
                    string HRid = string.Empty;

                    // Preare final accountname
                    if(csentry["ID"].IsPresent) {
                        HRid = csentry["ID"].Value;
                        finalaccountname = IDprefix + HRid;
                    } else {
                        throw new EntryPointNotImplementedException("ID was not imported from HR connector space or some values are missing");
                        break;
                    }

                    // Write final accountname to Metaverse
                    // First check if final accountname already exists
                    if(mventry["accountName"].IsPresent) {
                        // Do nothing it is present
                    } else {
                        // Write new value
                        mventry["accountName"].Value = finalaccountname;
                    }
                break;


				case "displayName":
					
                    // Declare needed vars
                    string finaldisplayname = string.Empty;
                    string imie = string.Empty;
                    string nazwisko = string.Empty;

                    // Preare final displayname
					if(csentry["Imie"].IsPresent && csentry["Nazwisko"].IsPresent) {
                        imie = csentry["Imie"].Value;
                        nazwisko = csentry["Nazwisko"].Value;
                        finaldisplayname = nazwisko + " " + imie;
                        finaldisplayname = finaldisplayname.ToUpper();
                    } else {
                        throw new EntryPointNotImplementedException("Imie lub Nazwisko was not imported from HR connector space");
                        break;
                    }

                    // Write final displayname to Metaverse
                    mventry["displayName"].Value = finaldisplayname;
                
                break;


				default:
					// TODO: remove the following statement and add your default script here
					throw new EntryPointNotImplementedException();
			}
        }

        void IMASynchronization.MapAttributesForExport (string FlowRuleName, MVEntry mventry, CSEntry csentry)
        {
            //
			// TODO: write your export attribute flow code
			//
            throw new EntryPointNotImplementedException();
        }
	}
}
