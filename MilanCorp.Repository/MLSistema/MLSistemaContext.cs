using Microsoft.EntityFrameworkCore;
using MilanCorp.Domain;

namespace MilanCorp.Repository
{
    public partial class MLSistemaContext : DbContext
    {
        public MLSistemaContext()
        {
        }

        public MLSistemaContext(DbContextOptions<MLSistemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MlarquivosBens> MlarquivosBens { get; set; }
        public virtual DbSet<Mlbens> Mlbens { get; set; }
        public virtual DbSet<MlboletosPortoSeg> MlboletosPortoSeg { get; set; }
        public virtual DbSet<MlcategoriasVeiculos> MlcategoriasVeiculos { get; set; }
        public virtual DbSet<Mlcoligados> Mlcoligados { get; set; }
        public virtual DbSet<Mlcomitentes> Mlcomitentes { get; set; }
        public virtual DbSet<Mlcompradores> Mlcompradores { get; set; }
        public virtual DbSet<MlcompradoresEnd> MlcompradoresEnd { get; set; }
        public virtual DbSet<MldespesasBem> MldespesasBem { get; set; }
        public virtual DbSet<MldespesasNomes> MldespesasNomes { get; set; }
        public virtual DbSet<MldespesasReembolsos> MldespesasReembolsos { get; set; }
        public virtual DbSet<MldocumentosVeic> MldocumentosVeic { get; set; }
        public virtual DbSet<MlformaPagamento> MlformaPagamento { get; set; }
        public virtual DbSet<Mlleiloes> Mlleiloes { get; set; }
        public virtual DbSet<Mllocais> Mllocais { get; set; }
        public virtual DbSet<MllogsAlteracoes> MllogsAlteracoes { get; set; }
        public virtual DbSet<Mllotes> Mllotes { get; set; }
        public virtual DbSet<MllotesEntregues> MllotesEntregues { get; set; }
        public virtual DbSet<MlmarcasVeiculos> MlmarcasVeiculos { get; set; }
        public virtual DbSet<Mlmateriais> Mlmateriais { get; set; }
        public virtual DbSet<MlprocessoTransf> MlprocessoTransf { get; set; }
        public virtual DbSet<MlremocoesVeic> MlremocoesVeic { get; set; }
        public virtual DbSet<MltiposBens> MltiposBens { get; set; }
        public virtual DbSet<Mlveiculos> Mlveiculos { get; set; }
        public virtual DbSet<RbacessosAdm> RbacessosAdm { get; set; }
        public virtual DbSet<Rbadm> Rbadm { get; set; }
        public virtual DbSet<RbadmComit> RbadmComit { get; set; }
        public virtual DbSet<Rbaplicacoes> Rbaplicacoes { get; set; }
        public virtual DbSet<RbgrupoAdm> RbgrupoAdm { get; set; }
        public virtual DbSet<RblogBloqueios> RblogBloqueios { get; set; }
        public virtual DbSet<RblogsAdm> RblogsAdm { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<MlarquivosBens>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLArquivosBens");

                entity.Property(e => e.AlteradoPor)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NomeArquivoCompleto)
                    .IsRequired()
                    .HasMaxLength(230)
                    .IsUnicode(false);

                entity.Property(e => e.NomeArquivoOriginal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pasta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Temporario)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CodBemNavigation)
                    .WithMany(p => p.MlarquivosBens)
                    .HasForeignKey(d => d.CodBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLArquivosBens_MLBens");
            });

            modelBuilder.Entity<Mlbens>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLBens");

                entity.HasIndex(e => new { e.Codigo, e.TipoBem })
                    .HasName("IX_MLBens")
                    .IsUnique();

                entity.Property(e => e.CaminhoFotoAnt)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DataEntrada).HasColumnType("datetime");

                entity.Property(e => e.DataRegistro).HasColumnType("datetime");

                entity.Property(e => e.DataSaida).HasColumnType("datetime");

                entity.Property(e => e.NomeFoto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SvId).HasColumnName("SV_ID");

                entity.Property(e => e.UltimaAlteracao).HasColumnType("datetime");

                entity.HasOne(d => d.CodColigadoNavigation)
                    .WithMany(p => p.Mlbens)
                    .HasForeignKey(d => d.CodColigado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLBens_MLColigados");

                entity.HasOne(d => d.LocalNavigation)
                    .WithMany(p => p.Mlbens)
                    .HasForeignKey(d => d.Local)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLBens_MLLocais");

                entity.HasOne(d => d.TipoBemNavigation)
                    .WithMany(p => p.Mlbens)
                    .HasForeignKey(d => d.TipoBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLBens_MLTiposBens");
            });

            modelBuilder.Entity<MlboletosPortoSeg>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLBoletosPortoSeg");

                entity.HasIndex(e => e.CodBem)
                    .HasName("IX_MLBoletosPortoSeg");

                entity.HasIndex(e => e.DataVencimento)
                    .HasName("IX_MLBoletosPortoSeg_1");

                entity.HasIndex(e => e.Status)
                    .HasName("IX_MLBoletosPortoSeg_2");

                entity.Property(e => e.DataEnvio).HasColumnType("datetime");

                entity.Property(e => e.DataImportacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataVencimento).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.Property(e => e.ValorPcv)
                    .HasColumnName("ValorPCV")
                    .HasColumnType("money");

                entity.HasOne(d => d.CodBemNavigation)
                    .WithMany(p => p.MlboletosPortoSeg)
                    .HasForeignKey(d => d.CodBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLBoletosPortoSeg_MLBens");
            });

            modelBuilder.Entity<MlcategoriasVeiculos>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLCategoriasVeiculos");

                entity.Property(e => e.CodChar)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mlcoligados>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLColigados");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodComitNavigation)
                    .WithMany(p => p.Mlcoligados)
                    .HasForeignKey(d => d.CodComit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLColigados_MLComitentes");
            });

            modelBuilder.Entity<Mlcomitentes>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLComitentes");

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.DespAcessoria).HasColumnType("money");

                entity.Property(e => e.DespRemocao).HasColumnType("money");

                entity.Property(e => e.DirComit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadiaNaPc).HasColumnName("EstadiaNaPC");

                entity.Property(e => e.EstadiaValorMaterial).HasColumnType("money");

                entity.Property(e => e.EstadiaValorMoto).HasColumnType("money");

                entity.Property(e => e.EstadiaValorVeicLeve).HasColumnType("money");

                entity.Property(e => e.EstadiaValorVeicPesado).HasColumnType("money");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obsloteamento)
                    .HasColumnName("OBSLoteamento")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mlcompradores>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLCompradores");

                entity.Property(e => e.BairroOld)
                    .HasColumnName("BairroOLD")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cepold)
                    .HasColumnName("CEPOLD")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.CidadeOld)
                    .HasColumnName("CidadeOLD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementoOld)
                    .HasColumnName("ComplementoOLD")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Contato)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ContatoCpf)
                    .HasColumnName("ContatoCPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ddd)
                    .HasColumnName("DDD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoOld)
                    .HasColumnName("EnderecoOLD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fantasia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fone1)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Fone2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ie)
                    .HasColumnName("IE")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.MbbclienteSap)
                    .HasColumnName("MBBClienteSAP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nascimento).HasColumnType("datetime");

                entity.Property(e => e.NumeroOld)
                    .HasColumnName("NumeroOLD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocialAbrev)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RgorgaoExp)
                    .HasColumnName("RGOrgaoExp")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StatusObs)
                    .HasColumnName("StatusOBS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Ufold)
                    .HasColumnName("UFOLD")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MlcompradoresEnd>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLCompradoresEnd");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CodCidade)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCompradorNavigation)
                    .WithMany(p => p.MlcompradoresEnd)
                    .HasForeignKey(d => d.CodComprador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLCompradoresEnd_MLCompradores");
            });

            modelBuilder.Entity<MldespesasBem>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLDespesasBem");

                entity.HasIndex(e => e.CodBem)
                    .HasName("IX_MLDespesasBem");

                entity.Property(e => e.DataRegistro).HasColumnType("datetime");

                entity.Property(e => e.DataVencimentoNf)
                    .HasColumnName("DataVencimentoNF")
                    .HasColumnType("datetime");

                entity.Property(e => e.NomePrestadorNf)
                    .HasColumnName("NomePrestadorNF")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumNf)
                    .HasColumnName("NumNF")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Observacoes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.CodBemNavigation)
                    .WithMany(p => p.MldespesasBem)
                    .HasForeignKey(d => d.CodBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLDespesasBem_MLBens");

                entity.HasOne(d => d.CodNomeDespesaNavigation)
                    .WithMany(p => p.MldespesasBem)
                    .HasForeignKey(d => d.CodNomeDespesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLDespesasBem_MLDespesasTipos");
            });

            modelBuilder.Entity<MldespesasNomes>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_MLDespesasTipos");

                entity.ToTable("MLDespesasNomes");

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MldespesasReembolsos>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLDespesasReembolsos");

                entity.Property(e => e.AlteracaoDespesa).HasColumnType("datetime");

                entity.Property(e => e.DataDespesa).HasColumnType("datetime");

                entity.Property(e => e.DataReembolso).HasColumnType("datetime");

                entity.Property(e => e.DescricaoDespesa)
                    .IsRequired()
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescricaoReembolso)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.InfoBem)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Reembolsavel)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistroDespesa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegistroReembolso).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.ComitenteNavigation)
                    .WithMany(p => p.MldespesasReembolsos)
                    .HasForeignKey(d => d.Comitente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLDespesasReembolsos_MLComitentes");
            });

            modelBuilder.Entity<MldocumentosVeic>(entity =>
            {
                entity.HasKey(e => new { e.CodBem, e.CodTipoDoc });

                entity.ToTable("MLDocumentosVeic");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1200)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaAlteracao).HasColumnType("datetime");

                entity.HasOne(d => d.CodBemNavigation)
                    .WithMany(p => p.MldocumentosVeic)
                    .HasForeignKey(d => d.CodBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLDocumentosVeic_MLVeiculos");
            });

            modelBuilder.Entity<MlformaPagamento>(entity =>
            {
                entity.HasKey(e => e.CodFormaPgto)
                    .HasName("PK_MLVendas");

                entity.ToTable("MLFormaPagamento");

                entity.Property(e => e.AutenticacaoDep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeAgencia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeBanco)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeConta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChequeNumero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataDep).HasColumnType("datetime");

                entity.Property(e => e.DepositoConta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepositoOrigem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepositoTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoCc)
                    .HasColumnName("DescricaoCC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoComp)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoPagam)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrigiemDep)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodCompradorNavigation)
                    .WithMany(p => p.MlformaPagamento)
                    .HasForeignKey(d => d.CodComprador)
                    .HasConstraintName("FK_MLFormaPagamento_MLCompradores");
            });

            modelBuilder.Entity<Mlleiloes>(entity =>
            {
                entity.HasKey(e => e.CodLeilao);

                entity.ToTable("MLLeiloes");

                entity.Property(e => e.CodLeilaoWeb)
                    .HasColumnName("CodLeilaoWEB")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DataInicio).HasColumnType("datetime");

                entity.Property(e => e.Local)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LotesOnline)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MbbaprovadorPrecos)
                    .HasColumnName("MBBAprovadorPrecos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroLeilao)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroLeilaoLivro)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PastaFotos)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mllocais>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLLocais");

                entity.Property(e => e.Apelido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MllogsAlteracoes>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLLogsAlteracoes");

                entity.HasIndex(e => e.ChavesValores)
                    .HasName("IX_MLLogsAlteracoes");

                entity.Property(e => e.CampoAlterado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CampoValorAnterior)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CampoValorNovo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ChavesNomes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ChavesValores)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Tabela)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mllotes>(entity =>
            {
                entity.HasKey(e => new { e.CodLeilao, e.Lote });

                entity.ToTable("MLLotes");

                entity.HasIndex(e => e.CodBem);

                entity.HasIndex(e => new { e.CodLeilao, e.CodBem })
                    .HasName("IX_MLLotes_UnicoBem")
                    .IsUnique();

                entity.Property(e => e.Lote)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AvalLeiloeiro).HasColumnType("money");

                entity.Property(e => e.CodFipe)
                    .HasColumnName("CodFIPE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Comissao)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DataMolicar).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento).HasColumnType("datetime");

                entity.Property(e => e.DescBasica).IsUnicode(false);

                entity.Property(e => e.DescComplementar)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DescDestacada)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.DespAcessoria).HasColumnType("money");

                entity.Property(e => e.DespAdmin).HasColumnType("money");

                entity.Property(e => e.DespEmpilhadeira).HasColumnType("money");

                entity.Property(e => e.DespRemocao).HasColumnType("money");

                entity.Property(e => e.DespTransferencia).HasColumnType("money");

                entity.Property(e => e.Inventario)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Ipvaano).HasColumnName("IPVAAno");

                entity.Property(e => e.Ipvastatus).HasColumnName("IPVAStatus");

                entity.Property(e => e.MaxAtingidoBk)
                    .HasColumnName("MaxAtingido_BK")
                    .HasColumnType("money");

                entity.Property(e => e.MinimoCia).HasColumnType("money");

                entity.Property(e => e.MotivoCancelDesc)
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.NovoLote)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NvalteracaoAutorizada).HasColumnName("NVAlteracaoAutorizada");

                entity.Property(e => e.NvdataEmissao)
                    .HasColumnName("NVDataEmissao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nvip)
                    .HasColumnName("NVIp")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nvnumero)
                    .HasColumnName("NVNumero")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nvusuario)
                    .HasColumnName("NVUsuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObsAdicional)
                    .HasMaxLength(3500)
                    .IsUnicode(false);

                entity.Property(e => e.ObsAdicionalResumida)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.QuantLeilao).HasDefaultValueSql("((0))");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Unidade)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ValorCondicional).HasColumnType("money");

                entity.Property(e => e.ValorCondicionalDm)
                    .HasColumnName("ValorCondicionalDM")
                    .HasColumnType("money");

                entity.Property(e => e.ValorMaxAtingido)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorMolicar).HasColumnType("money");

                entity.Property(e => e.ValorVenda).HasColumnType("money");

                entity.Property(e => e.ValorVendaDm)
                    .HasColumnName("ValorVendaDM")
                    .HasColumnType("money");

                entity.Property(e => e.VendaImediataValor).HasColumnType("money");

                entity.HasOne(d => d.CodBemNavigation)
                    .WithMany(p => p.Mllotes)
                    .HasForeignKey(d => d.CodBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLLotes_MLBens");

                entity.HasOne(d => d.CodCompradorNavigation)
                    .WithMany(p => p.Mllotes)
                    .HasForeignKey(d => d.CodComprador)
                    .HasConstraintName("FK_MLLotes_MLCompradores");

                entity.HasOne(d => d.CodEnderecoNavigation)
                    .WithMany(p => p.Mllotes)
                    .HasForeignKey(d => d.CodEndereco)
                    .HasConstraintName("FK_MLLotes_MLCompradoresEnd");

                entity.HasOne(d => d.CodFormaPgtoNavigation)
                    .WithMany(p => p.Mllotes)
                    .HasForeignKey(d => d.CodFormaPgto)
                    .HasConstraintName("FK_MLLotes_MLFormaPagamento");

                entity.HasOne(d => d.CodLeilaoNavigation)
                    .WithMany(p => p.Mllotes)
                    .HasForeignKey(d => d.CodLeilao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLLotes_MLLeiloes");
            });

            modelBuilder.Entity<MllotesEntregues>(entity =>
            {
                entity.ToTable("MLLotesEntregues");

                entity.Property(e => e.DataRetirada)
                    .HasColumnType("datetime2(4)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .HasColumnName("imageName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lote)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NomeRetirou)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obs)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Rgretirou)
                    .IsRequired()
                    .HasColumnName("RGRetirou")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mllotes)
                    .WithMany(p => p.MllotesEntregues)
                    .HasForeignKey(d => new { d.CodLeilao, d.Lote })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLLotesEntregues_MLLotes");
            });

            modelBuilder.Entity<MlmarcasVeiculos>(entity =>
            {
                entity.HasKey(e => e.Nome);

                entity.ToTable("MLMarcasVeiculos");

                entity.Property(e => e.Nome)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Comum)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Mlmateriais>(entity =>
            {
                entity.ToTable("MLMateriais");

                entity.HasIndex(e => e.CodBem);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodMaterial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodTipoBem).HasDefaultValueSql("((3))");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Idcopia).HasColumnName("IDCopia");

                entity.Property(e => e.MbbdataImo)
                    .HasColumnName("MBBDataImo")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mbbinventario)
                    .HasColumnName("MBBInventario")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MbbnumImo)
                    .HasColumnName("MBBNumImo")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Mbbqu)
                    .HasColumnName("MBBQU")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Mbep)
                    .HasColumnName("MBEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Motorista)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Origem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrigemEst)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Transportador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unidade)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.Property(e => e.ValorEstadiaNaVenda).HasColumnType("money");

                entity.Property(e => e.ValorVenda).HasColumnType("money");

                entity.Property(e => e.Vistoriador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cod)
                    .WithMany(p => p.Mlmateriais)
                    .HasPrincipalKey(p => new { p.Codigo, p.TipoBem })
                    .HasForeignKey(d => new { d.CodBem, d.CodTipoBem })
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MLMateriais_MLBens");
            });

            modelBuilder.Entity<MlprocessoTransf>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLProcessoTransf");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1200)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.DataPendencia).HasColumnType("datetime");

                entity.Property(e => e.Mudancas)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodBemNavigation)
                    .WithMany(p => p.MlprocessoTransf)
                    .HasForeignKey(d => d.CodBem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLProcessoTransf_MLVeiculos");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.MlprocessoTransf)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MLProcessoTransf_RBAdm");
            });

            modelBuilder.Entity<MlremocoesVeic>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLRemocoesVeic");

                entity.Property(e => e.Assessoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataAutorPagEstadias).HasColumnType("datetime");

                entity.Property(e => e.DataAutorRemocao).HasColumnType("datetime");

                entity.Property(e => e.DataCancelamento).HasColumnType("datetime");

                entity.Property(e => e.DataEntradaMilan).HasColumnType("datetime");

                entity.Property(e => e.DataPedidoAutorRemocao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataPedidoRemocao).HasColumnType("datetime");

                entity.Property(e => e.DataPermanenciaJuridica).HasColumnType("datetime");

                entity.Property(e => e.DataRegistro).HasColumnType("datetime");

                entity.Property(e => e.EstadiaAte).HasColumnType("datetime");

                entity.Property(e => e.EstadiaBoleto)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EstadiaCobranca)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EstadiaReembolsavel)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EstadiaValorDia).HasColumnType("money");

                entity.Property(e => e.EstadiaVencimento).HasColumnType("datetime");

                entity.Property(e => e.GuinchoApreensaoBoleto)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GuinchoApreensaoCobranca)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GuinchoApreensaoReemb)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GuinchoApreensaoValor).HasColumnType("money");

                entity.Property(e => e.GuinchoApreensaoVencimento).HasColumnType("datetime");

                entity.Property(e => e.GuinchoBoleto)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GuinchoCobranca)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GuinchoReembolsavel)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GuinchoValor).HasColumnType("money");

                entity.Property(e => e.GuinchoVencimento).HasColumnType("datetime");

                entity.Property(e => e.LocalApoio)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApoioCidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApoioContato)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApoioTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApoioUf)
                    .HasColumnName("LocalApoioUF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApreensao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApreensaoCidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApreensaoContato)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalApreensaoUf)
                    .HasColumnName("LocalApreensaoUF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MotivoCancelamento)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MunckBoleto)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MunckCobranca)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MunckReemb)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MunckValor).HasColumnType("money");

                entity.Property(e => e.MunckVencimento).HasColumnType("datetime");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Transportador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transporte).HasColumnType("money");

                entity.Property(e => e.TransporteBoleto)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TransporteCobranca)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TransporteReembolsavel)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TransporteVencimento).HasColumnType("datetime");

                entity.Property(e => e.VeiculoAno)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VeiculoChassi)
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.VeiculoMarca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VeiculoModelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VeiculoPlaca)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodVeicNavigation)
                    .WithMany(p => p.MlremocoesVeic)
                    .HasForeignKey(d => d.CodVeic)
                    .HasConstraintName("FK_MLRemocoesVeic_MLVeiculos");
            });

            modelBuilder.Entity<MltiposBens>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("MLTiposBens");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mlveiculos>(entity =>
            {
                entity.HasKey(e => e.CodBem);

                entity.ToTable("MLVeiculos");

                entity.HasIndex(e => new { e.ItaudataPlanilha, e.ItaucodSeg })
                    .HasName("IX_MLVeiculosCSIItau");

                entity.Property(e => e.CodBem).ValueGeneratedNever();

                entity.Property(e => e.Abs).HasColumnName("ABS");

                entity.Property(e => e.AdiantEstadia).HasColumnType("money");

                entity.Property(e => e.AdiantNomeDespachante)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AdiantTxLocalizacao).HasColumnType("money");

                entity.Property(e => e.AdiantamentoDoc).HasColumnType("money");

                entity.Property(e => e.AnoMod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaminhoFotoAnt)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cd).HasColumnName("CD");

                entity.Property(e => e.Chassi)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Classificacao).HasDefaultValueSql("((1))");

                entity.Property(e => e.CodTipoBem).HasDefaultValueSql("((1))");

                entity.Property(e => e.Comb)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cor)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CustoEfetivoDoc).HasColumnType("money");

                entity.Property(e => e.DataAdiantamentoDoc).HasColumnType("datetime");

                entity.Property(e => e.DataCustoEfetivoDoc).HasColumnType("datetime");

                entity.Property(e => e.DataMolicar).HasColumnType("datetime");

                entity.Property(e => e.DataPagDiferenca).HasColumnType("datetime");

                entity.Property(e => e.DespTransf).HasColumnType("money");

                entity.Property(e => e.DivergenciaVistoria)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaVistoriaInLoco)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Etiqueta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaroisAuxiliaresLd).HasColumnName("FaroisAuxiliaresLD");

                entity.Property(e => e.FaroisAuxiliaresLe).HasColumnName("FaroisAuxiliaresLE");

                entity.Property(e => e.FaroisLd).HasColumnName("FaroisLD");

                entity.Property(e => e.FaroisLe).HasColumnName("FaroisLE");

                entity.Property(e => e.Filiais)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Idantigo).HasColumnName("IDAntigo");

                entity.Property(e => e.ItaucodSeg)
                    .HasColumnName("ITAUCodSeg")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.ItaudataPlanilha)
                    .HasColumnName("ITAUDataPlanilha")
                    .HasColumnType("datetime");

                entity.Property(e => e.LantLdd).HasColumnName("LantLDD");

                entity.Property(e => e.LantLdt).HasColumnName("LantLDT");

                entity.Property(e => e.LantLed).HasColumnName("LantLED");

                entity.Property(e => e.LantLet).HasColumnName("LantLET");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModuloIe).HasColumnName("ModuloIE");

                entity.Property(e => e.Motorista)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nfremocao)
                    .HasColumnName("NFRemocao")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumChequeDiferenca)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumMotor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacoesGerais)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Origem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrigemEst)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PneuLdd).HasColumnName("PneuLDD");

                entity.Property(e => e.PneuLdt).HasColumnName("PneuLDT");

                entity.Property(e => e.PneuLed).HasColumnName("PneuLED");

                entity.Property(e => e.PneuLet).HasColumnName("PneuLET");

                entity.Property(e => e.RadioAmfm).HasColumnName("RadioAMFM");

                entity.Property(e => e.Renavam)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Salvado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sinistro)
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.SvLeilao)
                    .HasColumnName("SV_Leilao")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SvLote)
                    .HasColumnName("SV_Lote")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Transportador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorAvaria).HasColumnType("money");

                entity.Property(e => e.ValorCartorio).HasColumnType("money");

                entity.Property(e => e.ValorDiligencia).HasColumnType("money");

                entity.Property(e => e.ValorEscob)
                    .HasColumnName("ValorESCOB")
                    .HasColumnType("money");

                entity.Property(e => e.ValorEstadia).HasColumnType("money");

                entity.Property(e => e.ValorEstadiaNaVenda).HasColumnType("money");

                entity.Property(e => e.ValorGuinchoApreensao).HasColumnType("money");

                entity.Property(e => e.ValorGuinchoLocal).HasColumnType("money");

                entity.Property(e => e.ValorLiquido).HasColumnType("money");

                entity.Property(e => e.ValorMolicar).HasColumnType("money");

                entity.Property(e => e.ValorRemocao).HasColumnType("money");

                entity.Property(e => e.ValorVistoriaInLoco).HasColumnType("money");

                entity.Property(e => e.VidroPortaLdd).HasColumnName("VidroPortaLDD");

                entity.Property(e => e.VidroPortaLdt).HasColumnName("VidroPortaLDT");

                entity.Property(e => e.VidroPortaLed).HasColumnName("VidroPortaLED");

                entity.Property(e => e.VidroPortaLet).HasColumnName("VidroPortaLET");

                entity.Property(e => e.Vistoriador)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RbacessosAdm>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("RBAcessosAdm");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pagina)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodAplicacaoNavigation)
                    .WithMany(p => p.RbacessosAdm)
                    .HasForeignKey(d => d.CodAplicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RBAcessosAdm_RBAplicacoes");
            });

            modelBuilder.Entity<Rbadm>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("RBAdm");

                entity.Property(e => e.DataBloqueio).HasColumnType("datetime");

                entity.Property(e => e.MotivoBloqueio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioBloqueado).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.CodAplicacaoNavigation)
                    .WithMany(p => p.Rbadm)
                    .HasForeignKey(d => d.CodAplicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RBAdm_RBAplicacoes");
            });

            modelBuilder.Entity<RbadmComit>(entity =>
            {
                entity.HasKey(e => new { e.CodAdm, e.CodComit });

                entity.ToTable("RBAdm_Comit");

                entity.HasOne(d => d.CodAdmNavigation)
                    .WithMany(p => p.RbadmComit)
                    .HasForeignKey(d => d.CodAdm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RBAdm_Comit_RBAdm");

                entity.HasOne(d => d.CodComitNavigation)
                    .WithMany(p => p.RbadmComit)
                    .HasForeignKey(d => d.CodComit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RBAdm_Comit_Comitentes");
            });

            modelBuilder.Entity<Rbaplicacoes>(entity =>
            {
                entity.HasKey(e => e.CodAplicacao);

                entity.ToTable("RBAplicacoes");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RbgrupoAdm>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("RBGrupoAdm");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodAplicacaoNavigation)
                    .WithMany(p => p.RbgrupoAdm)
                    .HasForeignKey(d => d.CodAplicacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RBGrupoAdm_RBAplicacoes");
            });

            modelBuilder.Entity<RblogBloqueios>(entity =>
            {
                entity.ToTable("RBLogBloqueios");

                entity.Property(e => e.Acesso)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnType("datetime2(4)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pagina)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RblogsAdm>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("RBLogsAdm");

                entity.Property(e => e.Acao)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence<int>("num_nota_venda")
                .StartsAt(309245)
                .HasMin(1);
        }
    }
}
