using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using DnsClient;

namespace _3._1_2WelcomeToTheTeamMyPeeps
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAnAdult => Age > 18;
        public Person(string firstName, string lastName, int age, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EmailAddress = emailAddress;
        }
        public bool Over18 () => IsAnAdult;
        public override string ToString() => $"{FirstName} {LastName}, Age: {Age}, Email: {EmailAddress}";
        public static bool IsEmailValid(string emailAddress)
        {
            try
            {
                var email = new MailAddress(emailAddress);
                return email.Address == email.ToString();
            }
            catch
            {
                return false;
            }
        }
        //Full disclosure, I found this validation method here: https://www.softfluent.com/blog/dev/2017/02/06/Advanced-email-address-validation-in-NET but I do understand all of what it does and I preferred it to all the regex expressions I saw because it seems that many may end up being too strict and still not catch many fake exceptions.
        public static Task<bool> IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                var host = mailAddress.Host;
                return CheckDnsEntriesAsync(host);
            }
            catch (FormatException)
            {
                return Task.FromResult(false);
            }
        }
        public static async Task<bool> CheckDnsEntriesAsync(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                lookup.Timeout = TimeSpan.FromSeconds(5);
                var result = await lookup.QueryAsync(domain, QueryType.ANY).ConfigureAwait(false);

                var records = result.Answers.Where(record => record.RecordType == DnsClient.Protocol.ResourceRecordType.A ||
                                                             record.RecordType == DnsClient.Protocol.ResourceRecordType.AAAA ||
                                                             record.RecordType == DnsClient.Protocol.ResourceRecordType.MX);
                return records.Any();
            }
            catch (DnsResponseException)
            {
                return false;
            }
        }

    }
}
