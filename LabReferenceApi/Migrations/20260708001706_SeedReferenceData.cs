using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabReferenceApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedReferenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Biomarkers",
                columns: new[] { "Id", "ClinicalContext", "DisplayName", "Name", "Panel" },
                values: new object[,]
                {
                    { 1, "White blood cells are the primary cells of the immune system. Elevated counts (leukocytosis) may indicate infection, inflammation, leukemia, or corticosteroid use. Low counts (leukopenia) increase infection risk and may indicate bone marrow suppression, viral illness, or autoimmune conditions.", "White Blood Cells (WBC)", "WBC", "CBC" },
                    { 2, "Red blood cells carry oxygen throughout the body via hemoglobin. Low counts suggest anemia from blood loss, hemolysis, or decreased production. Elevated counts (polycythemia) may indicate dehydration, chronic hypoxia, or polycythemia vera.", "Red Blood Cells (RBC)", "RBC", "CBC" },
                    { 3, "Hemoglobin is the oxygen-carrying protein in red blood cells. Low values indicate anemia; causes include iron deficiency, B12/folate deficiency, chronic disease, hemolysis, or blood loss. Critically low levels impair oxygen delivery to tissues.", "Hemoglobin (Hgb)", "Hemoglobin", "CBC" },
                    { 4, "Hematocrit is the percentage of blood volume occupied by red blood cells. It parallels hemoglobin trends and is used to assess anemia severity and guide transfusion decisions.", "Hematocrit (Hct)", "Hematocrit", "CBC" },
                    { 5, "Platelets are essential for primary hemostasis. Thrombocytopenia (low platelets) increases bleeding risk and may result from ITP, medications, bone marrow disease, or sepsis. Thrombocytosis may indicate reactive processes or essential thrombocythemia.", "Platelets (PLT)", "Platelets", "CBC" },
                    { 6, "MCV measures the average size of red blood cells. Low MCV (microcytic) suggests iron deficiency or thalassemia. High MCV (macrocytic) suggests B12/folate deficiency, liver disease, or hypothyroidism. Normal MCV with anemia points to chronic disease or acute blood loss.", "Mean Corpuscular Volume (MCV)", "MCV", "CBC" },
                    { 7, "MCH is the average amount of hemoglobin per red blood cell. It typically follows MCV trends and helps classify anemia as hypochromic (iron deficiency) or normochromic.", "Mean Corpuscular Hemoglobin (MCH)", "MCH", "CBC" },
                    { 8, "MCHC measures hemoglobin concentration relative to cell size. Low MCHC (hypochromia) is characteristic of iron deficiency anemia. Elevated MCHC may indicate hereditary spherocytosis or significant lipemia.", "Mean Corpuscular Hemoglobin Concentration (MCHC)", "MCHC", "CBC" },
                    { 9, "RDW reflects variation in red blood cell size (anisocytosis). Elevated RDW is an early marker of iron deficiency, B12/folate deficiency, or mixed nutritional anemias. A high RDW with normal MCV may precede other CBC changes.", "Red Cell Distribution Width (RDW)", "RDW", "CBC" },
                    { 10, "Sodium is the primary extracellular cation and regulates fluid balance. Hyponatremia causes neurological symptoms and may result from SIADH, heart failure, cirrhosis, or excessive water intake. Hypernatremia indicates dehydration or diabetes insipidus.", "Sodium (Na)", "Sodium", "CMP" },
                    { 11, "Potassium is critical for cardiac and neuromuscular function. Hypokalemia can cause arrhythmias, muscle weakness, and ileus. Hyperkalemia, particularly above 6.5 mEq/L, is a medical emergency due to risk of fatal cardiac arrhythmia.", "Potassium (K)", "Potassium", "CMP" },
                    { 12, "Chloride is the primary extracellular anion, closely linked to sodium balance. Abnormalities are often secondary to acid-base disturbances. Hypochloremia occurs in metabolic alkalosis; hyperchloremia occurs in hyperchloremic metabolic acidosis or dehydration.", "Chloride (Cl)", "Chloride", "CMP" },
                    { 13, "Serum CO2 primarily reflects bicarbonate and is used to assess acid-base status. Low CO2 suggests metabolic acidosis (DKA, renal failure, lactic acidosis). High CO2 suggests metabolic alkalosis (vomiting, diuretic use, hyperaldosteronism).", "Carbon Dioxide / Bicarbonate (CO2)", "CO2", "CMP" },
                    { 14, "Calcium is essential for neuromuscular function, cardiac contractility, and bone mineralization. Hypocalcemia causes tetany, seizures, and prolonged QT. Hypercalcemia may indicate hyperparathyroidism, malignancy, sarcoidosis, or excess vitamin D.", "Calcium (Ca)", "Calcium", "CMP" },
                    { 15, "BUN reflects protein catabolism and renal urea excretion. Elevated BUN indicates renal impairment, dehydration, high protein intake, GI bleeding, or catabolic states. The BUN:Creatinine ratio helps differentiate prerenal from intrinsic renal causes.", "Blood Urea Nitrogen (BUN)", "BUN", "CMP" },
                    { 16, "Creatinine is a byproduct of muscle metabolism filtered by the kidneys. It is a more specific indicator of renal function than BUN alone. Rising creatinine indicates declining GFR. Reference ranges differ by sex due to differences in muscle mass.", "Creatinine (Cr)", "Creatinine", "CMP" },
                    { 17, "eGFR estimates kidney filtration capacity, calculated from creatinine, age, and sex. Values below 60 for more than 3 months indicate chronic kidney disease. Values below 15 indicate kidney failure. eGFR is used to stage CKD and dose renally cleared medications.", "Estimated Glomerular Filtration Rate (eGFR)", "eGFR", "CMP" },
                    { 18, "Fasting glucose is the primary screening test for diabetes and prediabetes. Values 100–125 mg/dL indicate impaired fasting glucose (prediabetes). Values ≥126 mg/dL on two occasions confirm diabetes. Critical hypoglycemia causes altered consciousness and seizures.", "Glucose (fasting)", "Glucose", "CMP" },
                    { 19, "AST is found in hepatocytes, cardiac muscle, and skeletal muscle. Elevated AST indicates hepatocellular injury, myocardial infarction, or muscle damage. The AST:ALT ratio is useful — a ratio >2 suggests alcoholic liver disease; a ratio <1 suggests viral hepatitis.", "Aspartate Aminotransferase (AST)", "AST", "CMP" },
                    { 20, "ALT is a liver-specific enzyme and the preferred marker of hepatocellular injury. Markedly elevated ALT (>10× normal) suggests acute viral hepatitis, ischemic hepatitis, or drug-induced liver injury. Mildly elevated ALT is common in NAFLD and metabolic syndrome.", "Alanine Aminotransferase (ALT)", "ALT", "CMP" },
                    { 21, "ALP is produced in the liver, bone, intestine, and placenta. Isolated ALP elevation suggests cholestatic liver disease or bone disorders (Paget disease, bone metastases). Concurrent elevation of ALP and GGT confirms hepatic origin.", "Alkaline Phosphatase (ALP)", "ALP", "CMP" },
                    { 22, "Bilirubin is a breakdown product of heme. Elevated total bilirubin causes jaundice. Pre-hepatic elevation suggests hemolysis; hepatic elevation suggests hepatocellular disease or conjugation defects (Gilbert syndrome); post-hepatic elevation suggests biliary obstruction.", "Total Bilirubin (T. Bili)", "Total Bilirubin", "CMP" },
                    { 23, "Total protein reflects albumin plus globulins. Low values indicate malnutrition, malabsorption, liver disease, or protein-losing enteropathy/nephropathy. High values may indicate dehydration or paraprotein production (multiple myeloma).", "Total Protein", "Total Protein", "CMP" },
                    { 24, "Albumin is the most abundant plasma protein and a marker of nutritional status and hepatic synthetic function. Low albumin is associated with poor outcomes in hospitalized patients. It also affects interpretation of other labs — notably calcium, which is partly albumin-bound.", "Albumin", "Albumin", "CMP" },
                    { 25, "Total cholesterol is the sum of LDL, HDL, and VLDL cholesterol. Elevated levels are a modifiable risk factor for atherosclerotic cardiovascular disease (ASCVD). Interpretation is most meaningful in the context of the full lipid profile and cardiovascular risk factors.", "Total Cholesterol", "Total Cholesterol", "Lipid Panel" },
                    { 26, "LDL ('bad' cholesterol) is the primary atherogenic lipoprotein. Elevated LDL drives atherosclerotic plaque formation. Target LDL depends on cardiovascular risk category — high-risk patients (prior ASCVD, diabetes) require levels <70 mg/dL. Statins are the primary treatment for elevated LDL.", "LDL Cholesterol", "LDL", "Lipid Panel" },
                    { 27, "HDL ('good' cholesterol) facilitates reverse cholesterol transport from arterial walls to the liver. Low HDL is an independent cardiovascular risk factor. HDL reference ranges differ by sex — women typically have higher HDL than men. Levels above 60 mg/dL are considered cardioprotective.", "HDL Cholesterol", "HDL", "Lipid Panel" },
                    { 28, "Triglycerides are the primary storage form of fat. Elevated triglycerides (hypertriglyceridemia) are associated with ASCVD risk, metabolic syndrome, and pancreatitis at very high levels (>500 mg/dL). Triglycerides are most accurate on a fasting sample.", "Triglycerides (TG)", "Triglycerides", "Lipid Panel" },
                    { 29, "Non-HDL cholesterol is calculated as Total Cholesterol minus HDL and represents all atherogenic lipoproteins (LDL + VLDL + IDL + Lp(a)). It is a stronger predictor of ASCVD risk than LDL alone and does not require fasting. Target is typically 30 mg/dL above the LDL goal.", "Non-HDL Cholesterol (calculated)", "Non-HDL Cholesterol", "Lipid Panel" },
                    { 30, "TSH is the most sensitive test for thyroid dysfunction. Low TSH indicates hyperthyroidism (or TSH suppression from exogenous thyroid hormone). High TSH indicates primary hypothyroidism. Reference ranges are slightly broader in older adults. TSH should be the first-line thyroid test.", "Thyroid Stimulating Hormone (TSH)", "TSH", "Thyroid" },
                    { 31, "Free T3 is the biologically active thyroid hormone. Elevated Free T3 confirms hyperthyroidism, particularly T3 toxicosis. Low Free T3 may occur in severe non-thyroidal illness (low T3 syndrome) without true hypothyroidism. Useful when TSH is suppressed but Free T4 is normal.", "Free Triiodothyronine (Free T3)", "Free T3", "Thyroid" },
                    { 32, "Free T4 is the primary secretory product of the thyroid gland and the precursor to the active T3. Low Free T4 with high TSH confirms primary hypothyroidism. Low Free T4 with low TSH suggests central (pituitary or hypothalamic) hypothyroidism.", "Free Thyroxine (Free T4)", "Free T4", "Thyroid" },
                    { 33, "CRP is an acute-phase reactant produced by the liver in response to inflammation or infection. High-sensitivity CRP (hsCRP) stratifies cardiovascular risk. Markedly elevated CRP (>10 mg/L) suggests active bacterial infection, autoimmune flare, or tissue injury. CRP rises within hours and normalizes quickly with resolution.", "C-Reactive Protein (CRP)", "CRP", "Inflammatory Markers" },
                    { 34, "ESR measures the rate at which red blood cells settle in a tube and is a nonspecific marker of inflammation. It rises more slowly than CRP and remains elevated longer. ESR is useful for monitoring conditions like polymyalgia rheumatica, temporal arteritis, and multiple myeloma.", "Erythrocyte Sedimentation Rate (ESR)", "ESR", "Inflammatory Markers" },
                    { 35, "Ferritin is the primary intracellular iron storage protein. Low ferritin is the earliest and most specific marker of iron deficiency. Ferritin is also an acute-phase reactant — elevated ferritin may reflect inflammation, liver disease, or malignancy rather than iron overload, so clinical context is essential.", "Ferritin", "Ferritin", "Inflammatory Markers" },
                    { 36, "25-hydroxyvitamin D is the best indicator of vitamin D status. Deficiency (<20 ng/mL) is associated with bone disease, muscle weakness, and immune dysfunction. Insufficiency (20–29 ng/mL) is common and may warrant supplementation. Toxicity (>100 ng/mL) can cause hypercalcemia.", "25-Hydroxyvitamin D (Vitamin D)", "Vitamin D", "Vitamins & Minerals" },
                    { 37, "Vitamin B12 is essential for DNA synthesis and myelin maintenance. Deficiency causes macrocytic anemia, peripheral neuropathy, and subacute combined degeneration of the spinal cord. Risk groups include strict vegans, elderly patients, those with pernicious anemia, and patients on long-term metformin or PPIs.", "Vitamin B12 (Cobalamin)", "Vitamin B12", "Vitamins & Minerals" },
                    { 38, "Folate is required for nucleotide synthesis and cell division. Deficiency causes macrocytic megaloblastic anemia and is a critical risk factor for neural tube defects in early pregnancy. Causes include poor diet, malabsorption, alcoholism, and medications (methotrexate, phenytoin).", "Folate (Folic Acid)", "Folate", "Vitamins & Minerals" },
                    { 39, "Serum iron reflects circulating iron bound to transferrin. Low serum iron with low ferritin confirms iron deficiency. Low serum iron with normal or high ferritin suggests anemia of chronic disease. Iron should be interpreted alongside TIBC and ferritin for full iron status assessment.", "Serum Iron", "Iron", "Vitamins & Minerals" },
                    { 40, "TIBC reflects the blood's capacity to bind iron, primarily via transferrin. Elevated TIBC with low iron and low ferritin is characteristic of iron deficiency anemia. Low TIBC with elevated ferritin suggests anemia of chronic disease or iron overload.", "Total Iron Binding Capacity (TIBC)", "TIBC", "Vitamins & Minerals" },
                    { 41, "Magnesium is essential for neuromuscular function, enzyme activity, and cardiac stability. Hypomagnesemia causes muscle cramps, arrhythmias, and refractory hypokalemia. It is common in alcoholism, malabsorption, and with diuretic use. Critically low levels can precipitate ventricular arrhythmias.", "Magnesium (Mg)", "Magnesium", "Vitamins & Minerals" },
                    { 42, "Zinc is a cofactor for hundreds of enzymes and is critical for immune function, wound healing, and taste/smell. Deficiency causes dermatitis, alopecia, impaired wound healing, and immune dysfunction. Risk groups include those with poor dietary intake, malabsorption, or chronic diarrhea.", "Zinc (Zn)", "Zinc", "Vitamins & Minerals" }
                });

            migrationBuilder.InsertData(
                table: "ReferenceRanges",
                columns: new[] { "Id", "BiomarkerId", "CriticalHigh", "CriticalLow", "HighNormal", "LowNormal", "MaxAge", "MinAge", "SexFilter", "SiConversionFactor", "SiUnit", "Unit" },
                values: new object[,]
                {
                    { 1, 1, 30.0m, 2.0m, 11.0m, 4.5m, null, null, null, 1.0m, "10^9/L", "10^3/uL" },
                    { 2, 2, 7.0m, 2.5m, 5.9m, 4.5m, null, 18, "male", 1.0m, "10^12/L", "10^6/uL" },
                    { 3, 2, 7.0m, 2.5m, 5.2m, 4.0m, null, 18, "female", 1.0m, "10^12/L", "10^6/uL" },
                    { 4, 3, 20.0m, 7.0m, 17.5m, 13.5m, null, 18, "male", 10.0m, "g/L", "g/dL" },
                    { 5, 3, 20.0m, 7.0m, 16.0m, 12.0m, null, 18, "female", 10.0m, "g/L", "g/dL" },
                    { 6, 4, 60.0m, 21.0m, 53.0m, 41.0m, null, 18, "male", null, null, "%" },
                    { 7, 4, 60.0m, 21.0m, 46.0m, 36.0m, null, 18, "female", null, null, "%" },
                    { 8, 5, 1000.0m, 50.0m, 400.0m, 150.0m, null, null, null, 1.0m, "10^9/L", "10^3/uL" },
                    { 9, 6, null, null, 100.0m, 80.0m, null, null, null, null, null, "fL" },
                    { 10, 7, null, null, 33.0m, 27.0m, null, null, null, null, null, "pg" },
                    { 11, 8, 38.0m, null, 36.0m, 32.0m, null, null, null, null, null, "g/dL" },
                    { 12, 9, null, null, 14.5m, 11.5m, null, null, null, null, null, "%" },
                    { 13, 10, 160.0m, 120.0m, 145.0m, 136.0m, null, null, null, 1.0m, "mmol/L", "mEq/L" },
                    { 14, 11, 6.5m, 2.5m, 5.1m, 3.5m, null, null, null, 1.0m, "mmol/L", "mEq/L" },
                    { 15, 12, 120.0m, 80.0m, 107.0m, 98.0m, null, null, null, 1.0m, "mmol/L", "mEq/L" },
                    { 16, 13, 40.0m, 10.0m, 29.0m, 22.0m, null, null, null, 1.0m, "mmol/L", "mEq/L" },
                    { 17, 14, 13.0m, 7.0m, 10.5m, 8.5m, null, null, null, 0.25m, "mmol/L", "mg/dL" },
                    { 18, 15, 100.0m, null, 20.0m, 7.0m, null, null, null, 0.357m, "mmol/L", "mg/dL" },
                    { 19, 16, 10.0m, null, 1.3m, 0.7m, null, 18, "male", 88.4m, "umol/L", "mg/dL" },
                    { 20, 16, 10.0m, null, 1.1m, 0.5m, null, 18, "female", 88.4m, "umol/L", "mg/dL" },
                    { 21, 17, null, 15.0m, 200.0m, 60.0m, null, null, null, null, null, "mL/min/1.73m2" },
                    { 22, 18, 500.0m, 40.0m, 99.0m, 70.0m, null, null, null, 0.05551m, "mmol/L", "mg/dL" },
                    { 23, 19, 1000.0m, null, 40.0m, 10.0m, null, null, null, null, null, "U/L" },
                    { 24, 20, 1000.0m, null, 56.0m, 7.0m, null, null, "male", null, null, "U/L" },
                    { 25, 20, 1000.0m, null, 45.0m, 7.0m, null, null, "female", null, null, "U/L" },
                    { 26, 21, null, null, 147.0m, 44.0m, null, null, null, null, null, "U/L" },
                    { 27, 22, 15.0m, null, 1.2m, 0.1m, null, null, null, 17.1m, "umol/L", "mg/dL" },
                    { 28, 23, null, null, 8.2m, 6.3m, null, null, null, 10.0m, "g/L", "g/dL" },
                    { 29, 24, null, 2.0m, 5.0m, 3.5m, null, null, null, 10.0m, "g/L", "g/dL" },
                    { 30, 25, 300.0m, null, 200.0m, 0.0m, null, null, null, 0.02586m, "mmol/L", "mg/dL" },
                    { 31, 26, 190.0m, null, 130.0m, 0.0m, null, null, null, 0.02586m, "mmol/L", "mg/dL" },
                    { 32, 27, null, 25.0m, 200.0m, 40.0m, null, null, "male", 0.02586m, "mmol/L", "mg/dL" },
                    { 33, 27, null, 25.0m, 200.0m, 50.0m, null, null, "female", 0.02586m, "mmol/L", "mg/dL" },
                    { 34, 28, 500.0m, null, 150.0m, 0.0m, null, null, null, 0.01129m, "mmol/L", "mg/dL" },
                    { 35, 29, null, null, 130.0m, 0.0m, null, null, null, 0.02586m, "mmol/L", "mg/dL" },
                    { 36, 30, 10.0m, 0.1m, 4.0m, 0.4m, 60, 18, null, null, null, "mIU/L" },
                    { 37, 30, 10.0m, 0.1m, 5.5m, 0.4m, null, 60, null, null, null, "mIU/L" },
                    { 38, 31, null, null, 4.2m, 2.3m, null, null, null, 1.536m, "pmol/L", "pg/mL" },
                    { 39, 32, null, null, 1.8m, 0.8m, null, null, null, 12.87m, "pmol/L", "ng/dL" },
                    { 40, 33, 100.0m, null, 1.0m, 0.0m, null, null, null, null, null, "mg/L" },
                    { 41, 34, null, null, 15.0m, 0.0m, null, null, "male", null, null, "mm/hr" },
                    { 42, 34, null, null, 20.0m, 0.0m, null, null, "female", null, null, "mm/hr" },
                    { 43, 35, null, 10.0m, 336.0m, 24.0m, null, null, "male", null, null, "ng/mL" },
                    { 44, 35, null, 10.0m, 307.0m, 11.0m, null, null, "female", null, null, "ng/mL" },
                    { 45, 36, 150.0m, 10.0m, 100.0m, 30.0m, null, null, null, 0.4m, "nmol/L", "ng/mL" },
                    { 46, 37, null, 100.0m, 900.0m, 200.0m, null, null, null, 0.7378m, "pmol/L", "pg/mL" },
                    { 47, 38, null, 2.0m, 17.0m, 2.7m, null, null, null, 0.4413m, "nmol/L", "ng/mL" },
                    { 48, 39, null, 20.0m, 170.0m, 60.0m, null, null, "male", 0.179m, "umol/L", "mcg/dL" },
                    { 49, 39, null, 20.0m, 145.0m, 37.0m, null, null, "female", 0.179m, "umol/L", "mcg/dL" },
                    { 50, 40, null, null, 370.0m, 250.0m, null, null, null, 0.179m, "umol/L", "mcg/dL" },
                    { 51, 41, 3.5m, 1.2m, 2.2m, 1.7m, null, null, null, 0.4114m, "mmol/L", "mg/dL" },
                    { 52, 42, null, 30.0m, 120.0m, 60.0m, null, null, null, 0.153m, "umol/L", "mcg/dL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ReferenceRanges",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Biomarkers",
                keyColumn: "Id",
                keyValue: 42);
        }
    }
}
