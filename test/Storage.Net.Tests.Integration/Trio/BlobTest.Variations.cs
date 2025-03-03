﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Amazon;
using Storage.Net.Blobs;
using Xunit;

namespace Storage.Net.Tests.Integration.Blobs
{
   public class AzureBlobStorageFixture : BlobFixture
   {
      public AzureBlobStorageFixture() : base("lakeyv12/")
      {
      }

      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs
            .AzureBlobStorageWithSharedKey(settings.AzureStorageName, settings.AzureStorageKey);
            //.WithGzipCompression();
      }
   }

   public class AzureBlobStorageTest : BlobTest, IClassFixture<AzureBlobStorageFixture>
   {
      public AzureBlobStorageTest(AzureBlobStorageFixture fixture) : base(fixture)
      {
      }
   }

#if DEBUG
   public class AzureEmulatedBlobStorageFixture : BlobFixture
   {
      public AzureEmulatedBlobStorageFixture() : base("itest")
      {

      }

      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AzureBlobStorageWithLocalEmulator();
      }
   }

   public class AzureEmulatedBlobStorageTest : BlobTest, IClassFixture<AzureEmulatedBlobStorageFixture>
   {
      public AzureEmulatedBlobStorageTest(AzureEmulatedBlobStorageFixture fixture) : base(fixture)
      {

      }
   }
#endif

   public class AzureFilesFixture : BlobFixture
   {
      public AzureFilesFixture() : base("testshare")
      {

      }

      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AzureFiles(settings.AzureStorageName, settings.AzureStorageKey);
      }
   }

   public class AzureFilesTest : BlobTest, IClassFixture<AzureFilesFixture>
   {
      public AzureFilesTest(AzureFilesFixture fixture) : base(fixture)
      {

      }
   }

   public class AdlsGen1Fixture : BlobFixture
   {
      public AdlsGen1Fixture() : base("gen1fixture") { }

      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AzureDataLakeGen1StoreByClientSecret(
                  settings.AzureDataLakeStoreAccountName,
                  settings.AzureDataLakeTenantId,
                  settings.AzureDataLakePrincipalId,
                  settings.AzureDataLakePrincipalSecret);
      }
   }

   public class AdlsGen1Test : BlobTest, IClassFixture<AdlsGen1Fixture>
   {
      public AdlsGen1Test(AdlsGen1Fixture fixture) : base(fixture)
      {
      }
   }

   public class AdlsGen2Fixture : BlobFixture
   {
      public AdlsGen2Fixture() : base("integration")
      {

      }

      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AzureDataLakeStorageWithSharedKey(
            settings.AzureDataLakeGen2Name,
            settings.AzureDataLakeGen2Key);

         //return StorageFactory.Blobs.AzureDataLakeGen2StoreBySharedAccessKey(settings.AzureDataLakeGen2Name, settings.AzureDataLakeGen2Key);
      }
   }

   public class AdlsGen2Test : BlobTest, IClassFixture<AdlsGen2Fixture>
   {
      public AdlsGen2Test(AdlsGen2Fixture fixture) : base(fixture)
      {
      }
   }

   public class DiskDirectoryStorageFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.DirectoryFiles(TestDir);
      }
   }

   public class DiskDirectoryTest : BlobTest, IClassFixture<DiskDirectoryStorageFixture>
   {
      public DiskDirectoryTest(DiskDirectoryStorageFixture fixture) : base(fixture)
      {
      }
   }

   public class ZipFileFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.ZipFile(Path.Combine(TestDir, "test.zip"));
      }
   }

   public class ZipFileTest : BlobTest, IClassFixture<ZipFileFixture>
   {
      public ZipFileTest(ZipFileFixture fixture) : base(fixture)
      {
      }
   }

   public class AwsS3Fixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AwsS3(
                  settings.AwsAccessKeyId,
                  settings.AwsSecretAccessKey,
                  null,
                  settings.AwsTestBucketName,
                  settings.AwsTestBucketRegion);
      }
   }

   public class AwsS3Test : BlobTest, IClassFixture<AwsS3Fixture>
   {
      public AwsS3Test(AwsS3Fixture fixture) : base(fixture)
      {
      }
   }

   public class InMemoryFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.InMemory();
      }
   }

   public class InMemoryTest : BlobTest, IClassFixture<InMemoryFixture>
   {
      public InMemoryTest(InMemoryFixture fixture) : base(fixture)
      {
      }
   }

   public class AzureKeyVaultFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AzureKeyVault(
                  settings.KeyVaultUri,
                  settings.KeyVaultTenantId,
                  settings.KeyVaultClientId,
                  settings.KeyVaultSecret);
      }
   }

   public class AzureKeyVaultTest : BlobTest, IClassFixture<AzureKeyVaultFixture>
   {
      public AzureKeyVaultTest(AzureKeyVaultFixture fixture) : base(fixture)
      {
      }
   }

   public class FtpFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.Ftp(
            settings.FtpHostName,
            new NetworkCredential(settings.FtpUsername, settings.FtpPassword));
      }
   }

   /* i don't have an ftp server anymore
   public class FtpTest : BlobTest, IClassFixture<FtpFixture>
   {
      public FtpTest(FtpFixture fixture) : base(fixture)
      {

      }
   }*/

   public class AzdbfsFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.AzureDatabricksDbfs(settings.DatabricksBaseUri, settings.DatabricksToken, true);
      }
   }

   /* highly experimental
   public class AzdbfsTest : BlobTest, IClassFixture<AzdbfsFixture>
   {
      public AzdbfsTest(AzdbfsFixture fixture) : base(fixture)
      {
      }
   }
   */

   public class GcpFixture : BlobFixture
   {
      protected override IBlobStorage CreateStorage(ITestSettings settings)
      {
         return StorageFactory.Blobs.GoogleCloudStorageFromJson(
            settings.GcpStorageBucketName,
            settings.GcpStorageJsonCreds,
            true);
      }
   }

   public class GcpTest : BlobTest, IClassFixture<GcpFixture>
   {
      public GcpTest(GcpFixture fixture) : base(fixture)
      {

      }
   }
}
