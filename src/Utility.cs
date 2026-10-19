using System.Management;

namespace DesktopVerity;

internal static class Utility
{
    public static bool IsRunningInVirtualMachine()
    {
        try
        {
            using ManagementObjectSearcher searcher = new("SELECT Model, Manufacturer FROM Win32_ComputerSystem");
            using ManagementObjectCollection items = searcher.Get();

            foreach (ManagementBaseObject? item in items)
            {
                string manufacturer = item["Manufacturer"]?.ToString()?.ToLower() ?? "";
                string model = item["Model"]?.ToString()?.ToLower() ?? "";

                if (manufacturer.Contains("microsoft") && model.Contains("virtual")  // Hyper-V / Azure DevBox
                    || manufacturer.Contains("vmware")                               // VMware
                    || model.Contains("virtualbox")                                  // VirtualBox
                    || manufacturer.Contains("qemu") || model.Contains("kvm"))       // QEMU/KVM
                {
                    return true;
                }
            }
        }
        catch
        {
            // If WMI fails, we'll probably want the same optimizations for virtual machines anyways, so we will
            // return true.
            return true;
        }
        return false;
    }
}