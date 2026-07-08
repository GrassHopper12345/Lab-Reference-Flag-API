using LabReferenceApi.Models;

namespace LabReferenceApi.Data.Seed;

// ID Registry
// CBC:               1–9
// CMP:               10–24
// Lipid Panel:       25–29
// Thyroid:           30–32
// Inflammatory:      33–35
// Vitamins/Minerals: 36–42

public static class BiomarkerSeedData
{
    public static Biomarker[] GetBiomarkers() =>
    [
        // ── CBC ─────────────────────────────────────────────────────────────
        new Biomarker
        {
            Id = 1, Name = "WBC", DisplayName = "White Blood Cells (WBC)", Panel = "CBC",
            ClinicalContext = "White blood cells are the primary cells of the immune system. Elevated counts (leukocytosis) may indicate infection, inflammation, leukemia, or corticosteroid use. Low counts (leukopenia) increase infection risk and may indicate bone marrow suppression, viral illness, or autoimmune conditions."
        },
        new Biomarker
        {
            Id = 2, Name = "RBC", DisplayName = "Red Blood Cells (RBC)", Panel = "CBC",
            ClinicalContext = "Red blood cells carry oxygen throughout the body via hemoglobin. Low counts suggest anemia from blood loss, hemolysis, or decreased production. Elevated counts (polycythemia) may indicate dehydration, chronic hypoxia, or polycythemia vera."
        },
        new Biomarker
        {
            Id = 3, Name = "Hemoglobin", DisplayName = "Hemoglobin (Hgb)", Panel = "CBC",
            ClinicalContext = "Hemoglobin is the oxygen-carrying protein in red blood cells. Low values indicate anemia; causes include iron deficiency, B12/folate deficiency, chronic disease, hemolysis, or blood loss. Critically low levels impair oxygen delivery to tissues."
        },
        new Biomarker
        {
            Id = 4, Name = "Hematocrit", DisplayName = "Hematocrit (Hct)", Panel = "CBC",
            ClinicalContext = "Hematocrit is the percentage of blood volume occupied by red blood cells. It parallels hemoglobin trends and is used to assess anemia severity and guide transfusion decisions."
        },
        new Biomarker
        {
            Id = 5, Name = "Platelets", DisplayName = "Platelets (PLT)", Panel = "CBC",
            ClinicalContext = "Platelets are essential for primary hemostasis. Thrombocytopenia (low platelets) increases bleeding risk and may result from ITP, medications, bone marrow disease, or sepsis. Thrombocytosis may indicate reactive processes or essential thrombocythemia."
        },
        new Biomarker
        {
            Id = 6, Name = "MCV", DisplayName = "Mean Corpuscular Volume (MCV)", Panel = "CBC",
            ClinicalContext = "MCV measures the average size of red blood cells. Low MCV (microcytic) suggests iron deficiency or thalassemia. High MCV (macrocytic) suggests B12/folate deficiency, liver disease, or hypothyroidism. Normal MCV with anemia points to chronic disease or acute blood loss."
        },
        new Biomarker
        {
            Id = 7, Name = "MCH", DisplayName = "Mean Corpuscular Hemoglobin (MCH)", Panel = "CBC",
            ClinicalContext = "MCH is the average amount of hemoglobin per red blood cell. It typically follows MCV trends and helps classify anemia as hypochromic (iron deficiency) or normochromic."
        },
        new Biomarker
        {
            Id = 8, Name = "MCHC", DisplayName = "Mean Corpuscular Hemoglobin Concentration (MCHC)", Panel = "CBC",
            ClinicalContext = "MCHC measures hemoglobin concentration relative to cell size. Low MCHC (hypochromia) is characteristic of iron deficiency anemia. Elevated MCHC may indicate hereditary spherocytosis or significant lipemia."
        },
        new Biomarker
        {
            Id = 9, Name = "RDW", DisplayName = "Red Cell Distribution Width (RDW)", Panel = "CBC",
            ClinicalContext = "RDW reflects variation in red blood cell size (anisocytosis). Elevated RDW is an early marker of iron deficiency, B12/folate deficiency, or mixed nutritional anemias. A high RDW with normal MCV may precede other CBC changes."
        },

        // ── CMP ─────────────────────────────────────────────────────────────
        new Biomarker
        {
            Id = 10, Name = "Sodium", DisplayName = "Sodium (Na)", Panel = "CMP",
            ClinicalContext = "Sodium is the primary extracellular cation and regulates fluid balance. Hyponatremia causes neurological symptoms and may result from SIADH, heart failure, cirrhosis, or excessive water intake. Hypernatremia indicates dehydration or diabetes insipidus."
        },
        new Biomarker
        {
            Id = 11, Name = "Potassium", DisplayName = "Potassium (K)", Panel = "CMP",
            ClinicalContext = "Potassium is critical for cardiac and neuromuscular function. Hypokalemia can cause arrhythmias, muscle weakness, and ileus. Hyperkalemia, particularly above 6.5 mEq/L, is a medical emergency due to risk of fatal cardiac arrhythmia."
        },
        new Biomarker
        {
            Id = 12, Name = "Chloride", DisplayName = "Chloride (Cl)", Panel = "CMP",
            ClinicalContext = "Chloride is the primary extracellular anion, closely linked to sodium balance. Abnormalities are often secondary to acid-base disturbances. Hypochloremia occurs in metabolic alkalosis; hyperchloremia occurs in hyperchloremic metabolic acidosis or dehydration."
        },
        new Biomarker
        {
            Id = 13, Name = "CO2", DisplayName = "Carbon Dioxide / Bicarbonate (CO2)", Panel = "CMP",
            ClinicalContext = "Serum CO2 primarily reflects bicarbonate and is used to assess acid-base status. Low CO2 suggests metabolic acidosis (DKA, renal failure, lactic acidosis). High CO2 suggests metabolic alkalosis (vomiting, diuretic use, hyperaldosteronism)."
        },
        new Biomarker
        {
            Id = 14, Name = "Calcium", DisplayName = "Calcium (Ca)", Panel = "CMP",
            ClinicalContext = "Calcium is essential for neuromuscular function, cardiac contractility, and bone mineralization. Hypocalcemia causes tetany, seizures, and prolonged QT. Hypercalcemia may indicate hyperparathyroidism, malignancy, sarcoidosis, or excess vitamin D."
        },
        new Biomarker
        {
            Id = 15, Name = "BUN", DisplayName = "Blood Urea Nitrogen (BUN)", Panel = "CMP",
            ClinicalContext = "BUN reflects protein catabolism and renal urea excretion. Elevated BUN indicates renal impairment, dehydration, high protein intake, GI bleeding, or catabolic states. The BUN:Creatinine ratio helps differentiate prerenal from intrinsic renal causes."
        },
        new Biomarker
        {
            Id = 16, Name = "Creatinine", DisplayName = "Creatinine (Cr)", Panel = "CMP",
            ClinicalContext = "Creatinine is a byproduct of muscle metabolism filtered by the kidneys. It is a more specific indicator of renal function than BUN alone. Rising creatinine indicates declining GFR. Reference ranges differ by sex due to differences in muscle mass."
        },
        new Biomarker
        {
            Id = 17, Name = "eGFR", DisplayName = "Estimated Glomerular Filtration Rate (eGFR)", Panel = "CMP",
            ClinicalContext = "eGFR estimates kidney filtration capacity, calculated from creatinine, age, and sex. Values below 60 for more than 3 months indicate chronic kidney disease. Values below 15 indicate kidney failure. eGFR is used to stage CKD and dose renally cleared medications."
        },
        new Biomarker
        {
            Id = 18, Name = "Glucose", DisplayName = "Glucose (fasting)", Panel = "CMP",
            ClinicalContext = "Fasting glucose is the primary screening test for diabetes and prediabetes. Values 100–125 mg/dL indicate impaired fasting glucose (prediabetes). Values ≥126 mg/dL on two occasions confirm diabetes. Critical hypoglycemia causes altered consciousness and seizures."
        },
        new Biomarker
        {
            Id = 19, Name = "AST", DisplayName = "Aspartate Aminotransferase (AST)", Panel = "CMP",
            ClinicalContext = "AST is found in hepatocytes, cardiac muscle, and skeletal muscle. Elevated AST indicates hepatocellular injury, myocardial infarction, or muscle damage. The AST:ALT ratio is useful — a ratio >2 suggests alcoholic liver disease; a ratio <1 suggests viral hepatitis."
        },
        new Biomarker
        {
            Id = 20, Name = "ALT", DisplayName = "Alanine Aminotransferase (ALT)", Panel = "CMP",
            ClinicalContext = "ALT is a liver-specific enzyme and the preferred marker of hepatocellular injury. Markedly elevated ALT (>10× normal) suggests acute viral hepatitis, ischemic hepatitis, or drug-induced liver injury. Mildly elevated ALT is common in NAFLD and metabolic syndrome."
        },
        new Biomarker
        {
            Id = 21, Name = "ALP", DisplayName = "Alkaline Phosphatase (ALP)", Panel = "CMP",
            ClinicalContext = "ALP is produced in the liver, bone, intestine, and placenta. Isolated ALP elevation suggests cholestatic liver disease or bone disorders (Paget disease, bone metastases). Concurrent elevation of ALP and GGT confirms hepatic origin."
        },
        new Biomarker
        {
            Id = 22, Name = "Total Bilirubin", DisplayName = "Total Bilirubin (T. Bili)", Panel = "CMP",
            ClinicalContext = "Bilirubin is a breakdown product of heme. Elevated total bilirubin causes jaundice. Pre-hepatic elevation suggests hemolysis; hepatic elevation suggests hepatocellular disease or conjugation defects (Gilbert syndrome); post-hepatic elevation suggests biliary obstruction."
        },
        new Biomarker
        {
            Id = 23, Name = "Total Protein", DisplayName = "Total Protein", Panel = "CMP",
            ClinicalContext = "Total protein reflects albumin plus globulins. Low values indicate malnutrition, malabsorption, liver disease, or protein-losing enteropathy/nephropathy. High values may indicate dehydration or paraprotein production (multiple myeloma)."
        },
        new Biomarker
        {
            Id = 24, Name = "Albumin", DisplayName = "Albumin", Panel = "CMP",
            ClinicalContext = "Albumin is the most abundant plasma protein and a marker of nutritional status and hepatic synthetic function. Low albumin is associated with poor outcomes in hospitalized patients. It also affects interpretation of other labs — notably calcium, which is partly albumin-bound."
        },

        // ── Lipid Panel ──────────────────────────────────────────────────────
        new Biomarker
        {
            Id = 25, Name = "Total Cholesterol", DisplayName = "Total Cholesterol", Panel = "Lipid Panel",
            ClinicalContext = "Total cholesterol is the sum of LDL, HDL, and VLDL cholesterol. Elevated levels are a modifiable risk factor for atherosclerotic cardiovascular disease (ASCVD). Interpretation is most meaningful in the context of the full lipid profile and cardiovascular risk factors."
        },
        new Biomarker
        {
            Id = 26, Name = "LDL", DisplayName = "LDL Cholesterol", Panel = "Lipid Panel",
            ClinicalContext = "LDL ('bad' cholesterol) is the primary atherogenic lipoprotein. Elevated LDL drives atherosclerotic plaque formation. Target LDL depends on cardiovascular risk category — high-risk patients (prior ASCVD, diabetes) require levels <70 mg/dL. Statins are the primary treatment for elevated LDL."
        },
        new Biomarker
        {
            Id = 27, Name = "HDL", DisplayName = "HDL Cholesterol", Panel = "Lipid Panel",
            ClinicalContext = "HDL ('good' cholesterol) facilitates reverse cholesterol transport from arterial walls to the liver. Low HDL is an independent cardiovascular risk factor. HDL reference ranges differ by sex — women typically have higher HDL than men. Levels above 60 mg/dL are considered cardioprotective."
        },
        new Biomarker
        {
            Id = 28, Name = "Triglycerides", DisplayName = "Triglycerides (TG)", Panel = "Lipid Panel",
            ClinicalContext = "Triglycerides are the primary storage form of fat. Elevated triglycerides (hypertriglyceridemia) are associated with ASCVD risk, metabolic syndrome, and pancreatitis at very high levels (>500 mg/dL). Triglycerides are most accurate on a fasting sample."
        },
        new Biomarker
        {
            Id = 29, Name = "Non-HDL Cholesterol", DisplayName = "Non-HDL Cholesterol (calculated)", Panel = "Lipid Panel",
            ClinicalContext = "Non-HDL cholesterol is calculated as Total Cholesterol minus HDL and represents all atherogenic lipoproteins (LDL + VLDL + IDL + Lp(a)). It is a stronger predictor of ASCVD risk than LDL alone and does not require fasting. Target is typically 30 mg/dL above the LDL goal."
        },

        // ── Thyroid ──────────────────────────────────────────────────────────
        new Biomarker
        {
            Id = 30, Name = "TSH", DisplayName = "Thyroid Stimulating Hormone (TSH)", Panel = "Thyroid",
            ClinicalContext = "TSH is the most sensitive test for thyroid dysfunction. Low TSH indicates hyperthyroidism (or TSH suppression from exogenous thyroid hormone). High TSH indicates primary hypothyroidism. Reference ranges are slightly broader in older adults. TSH should be the first-line thyroid test."
        },
        new Biomarker
        {
            Id = 31, Name = "Free T3", DisplayName = "Free Triiodothyronine (Free T3)", Panel = "Thyroid",
            ClinicalContext = "Free T3 is the biologically active thyroid hormone. Elevated Free T3 confirms hyperthyroidism, particularly T3 toxicosis. Low Free T3 may occur in severe non-thyroidal illness (low T3 syndrome) without true hypothyroidism. Useful when TSH is suppressed but Free T4 is normal."
        },
        new Biomarker
        {
            Id = 32, Name = "Free T4", DisplayName = "Free Thyroxine (Free T4)", Panel = "Thyroid",
            ClinicalContext = "Free T4 is the primary secretory product of the thyroid gland and the precursor to the active T3. Low Free T4 with high TSH confirms primary hypothyroidism. Low Free T4 with low TSH suggests central (pituitary or hypothalamic) hypothyroidism."
        },

        // ── Inflammatory Markers ─────────────────────────────────────────────
        new Biomarker
        {
            Id = 33, Name = "CRP", DisplayName = "C-Reactive Protein (CRP)", Panel = "Inflammatory Markers",
            ClinicalContext = "CRP is an acute-phase reactant produced by the liver in response to inflammation or infection. High-sensitivity CRP (hsCRP) stratifies cardiovascular risk. Markedly elevated CRP (>10 mg/L) suggests active bacterial infection, autoimmune flare, or tissue injury. CRP rises within hours and normalizes quickly with resolution."
        },
        new Biomarker
        {
            Id = 34, Name = "ESR", DisplayName = "Erythrocyte Sedimentation Rate (ESR)", Panel = "Inflammatory Markers",
            ClinicalContext = "ESR measures the rate at which red blood cells settle in a tube and is a nonspecific marker of inflammation. It rises more slowly than CRP and remains elevated longer. ESR is useful for monitoring conditions like polymyalgia rheumatica, temporal arteritis, and multiple myeloma."
        },
        new Biomarker
        {
            Id = 35, Name = "Ferritin", DisplayName = "Ferritin", Panel = "Inflammatory Markers",
            ClinicalContext = "Ferritin is the primary intracellular iron storage protein. Low ferritin is the earliest and most specific marker of iron deficiency. Ferritin is also an acute-phase reactant — elevated ferritin may reflect inflammation, liver disease, or malignancy rather than iron overload, so clinical context is essential."
        },

        // ── Vitamins & Minerals ──────────────────────────────────────────────
        new Biomarker
        {
            Id = 36, Name = "Vitamin D", DisplayName = "25-Hydroxyvitamin D (Vitamin D)", Panel = "Vitamins & Minerals",
            ClinicalContext = "25-hydroxyvitamin D is the best indicator of vitamin D status. Deficiency (<20 ng/mL) is associated with bone disease, muscle weakness, and immune dysfunction. Insufficiency (20–29 ng/mL) is common and may warrant supplementation. Toxicity (>100 ng/mL) can cause hypercalcemia."
        },
        new Biomarker
        {
            Id = 37, Name = "Vitamin B12", DisplayName = "Vitamin B12 (Cobalamin)", Panel = "Vitamins & Minerals",
            ClinicalContext = "Vitamin B12 is essential for DNA synthesis and myelin maintenance. Deficiency causes macrocytic anemia, peripheral neuropathy, and subacute combined degeneration of the spinal cord. Risk groups include strict vegans, elderly patients, those with pernicious anemia, and patients on long-term metformin or PPIs."
        },
        new Biomarker
        {
            Id = 38, Name = "Folate", DisplayName = "Folate (Folic Acid)", Panel = "Vitamins & Minerals",
            ClinicalContext = "Folate is required for nucleotide synthesis and cell division. Deficiency causes macrocytic megaloblastic anemia and is a critical risk factor for neural tube defects in early pregnancy. Causes include poor diet, malabsorption, alcoholism, and medications (methotrexate, phenytoin)."
        },
        new Biomarker
        {
            Id = 39, Name = "Iron", DisplayName = "Serum Iron", Panel = "Vitamins & Minerals",
            ClinicalContext = "Serum iron reflects circulating iron bound to transferrin. Low serum iron with low ferritin confirms iron deficiency. Low serum iron with normal or high ferritin suggests anemia of chronic disease. Iron should be interpreted alongside TIBC and ferritin for full iron status assessment."
        },
        new Biomarker
        {
            Id = 40, Name = "TIBC", DisplayName = "Total Iron Binding Capacity (TIBC)", Panel = "Vitamins & Minerals",
            ClinicalContext = "TIBC reflects the blood's capacity to bind iron, primarily via transferrin. Elevated TIBC with low iron and low ferritin is characteristic of iron deficiency anemia. Low TIBC with elevated ferritin suggests anemia of chronic disease or iron overload."
        },
        new Biomarker
        {
            Id = 41, Name = "Magnesium", DisplayName = "Magnesium (Mg)", Panel = "Vitamins & Minerals",
            ClinicalContext = "Magnesium is essential for neuromuscular function, enzyme activity, and cardiac stability. Hypomagnesemia causes muscle cramps, arrhythmias, and refractory hypokalemia. It is common in alcoholism, malabsorption, and with diuretic use. Critically low levels can precipitate ventricular arrhythmias."
        },
        new Biomarker
        {
            Id = 42, Name = "Zinc", DisplayName = "Zinc (Zn)", Panel = "Vitamins & Minerals",
            ClinicalContext = "Zinc is a cofactor for hundreds of enzymes and is critical for immune function, wound healing, and taste/smell. Deficiency causes dermatitis, alopecia, impaired wound healing, and immune dysfunction. Risk groups include those with poor dietary intake, malabsorption, or chronic diarrhea."
        },
    ];
}
